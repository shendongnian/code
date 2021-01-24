using System.Reflection;
using System.IO;
using System;
public static class Extensions {
	private static string GetDirectory(this Assembly a) {
		string codeBase = a.CodeBase;
		UriBuilder uri = new UriBuilder(codeBase);
		string path = Uri.UnescapeDataString(uri.Path);
		return Path.GetDirectoryName(path);
	}
	private static void AlterLogPath(this log4net.Repository.ILoggerRepository repo, string newPath, string directory="") {
		log4net.Repository.Hierarchy.Hierarchy h = (log4net.Repository.Hierarchy.Hierarchy) repo;
		foreach (log4net.Appender.IAppender a in h.Root.Appenders) {
			if (a is log4net.Appender.FileAppender) {
				var fa = (log4net.Appender.FileAppender)a;
				var fileName = Path.GetFileName(fa.File);
				fa.File = newPath + (String.IsNullOrEmpty(directory)?"":(directory + Path.DirectorySeparatorChar.ToString())); // edit: filename is attached after next line automatically.
				fa.ActivateOptions();
				break;
			}
		}
	}
}
and in the bootup (via `[assembly: System.Web.PreApplicationStartMethod]` or otherwise for asp), or main app..
static void Main() {
	var PATH = Assembly.GetExecutingAssembly().GetDirectory() + Path.DirectorySeparatorChar.ToString();
	log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(PATH + "log4net.config"));
	log4net.LogManager.GetRepository().AlterLogPath(PATH, "Logs");
}
