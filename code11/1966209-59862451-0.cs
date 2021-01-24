c-sharp
using System.Reflection;
using log4net;
namespace YourNamespace
{
    internal static class MyLogger
    {
        private static readonly ILog Logger =
                                 LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        internal static string LogSomething()
        {
            Logger.Info("something");
            return "Info";
        }
    }
}
**Elsewhere in YourNamespace**
string strLogLevel  = MyLogger.LogSomething();
