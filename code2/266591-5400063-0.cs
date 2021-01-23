	using System;
	using System.Linq;
	using System.IO;
	using System.Text;
	using System.Text.RegularExpressions;
	using System.Collections.Generic;
	namespace O
	{
		static class X
		{
			private static readonly Regex _xml2pdf = new Regex("(_.*).xml$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
			internal static void MoveFileGroups(string uploadFolder)
			{
				string workingFilePath = Path.Combine(uploadFolder, "PROGRESS");
				var groups = new DirectoryInfo(uploadFolder)
					.GetFiles()
					.GroupBy(fi => _xml2pdf.Replace(fi.Name, ".pdf"), StringComparer.InvariantCultureIgnoreCase)
					.Where(group => group.Count() >1);
				foreach (var group in groups)
				{
					if (!group.Any(fi => File.Exists(Path.Combine(workingFilePath, fi.Name))))
						foreach (var file in group)
							file.MoveTo(Path.Combine(workingFilePath, file.Name));
				}
			}
			public static void Main(string[]args)
			{
			}
		}
	}
