        using System;
        using System.Diagnostics;
        using System.IO;
        using System.Text.RegularExpressions;
        using IISVersionManagerLibrary;
        using Microsoft.Web.Administration;
        public class Website
        {
            private const string DefaultAppPool = "Clr4IntegratedAppPool";
            private const string DefaultIISVersion = "8.0";
            private static readonly Random Random = new Random();
            private readonly IIISExpressProcessUtility _iis;
            private readonly string _name;
            private readonly string _path;
            private readonly int _port;
            private readonly string _appPool;
            private readonly string _iisPath;
            private readonly string _iisArguments;
            private readonly string _iisConfigPath;
            private uint _iisHandle;
            private Website(string path, string name, int port, string appPool, string iisVersion)
            {
                _path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, path));
                _name = name;
                _port = port;
                _appPool = appPool;
                _iis = (IIISExpressProcessUtility)new IISVersionManager()
                    .GetVersionObject(iisVersion, IIS_PRODUCT_TYPE.IIS_PRODUCT_EXPRESS)
                    .GetPropertyValue("expressProcessHelper");
                var commandLine = _iis.ConstructCommandLine(name, "", appPool, "");
                var commandLineParts = new Regex("\\\"(.*?)\\\" (.*)").Match(commandLine);
                _iisPath = commandLineParts.Groups[1].Value;
                _iisArguments = commandLineParts.Groups[2].Value;
                _iisConfigPath = new Regex("\\/config:\\\"(.*?)\\\"").Match(commandLine).Groups[1].Value;
                Url = string.Format("http://localhost:{0}/", _port);
            }
            public static Website Create(string path,
                string name = null, int? port = null,
                string appPool = DefaultAppPool,
                string iisVersion = DefaultIISVersion)
            {
                return new Website(path,
                    name ?? Guid.NewGuid().ToString("N"),
                    port ?? Random.Next(30000, 40000),
                    appPool, iisVersion);
            }
            public string Url { get; private set; }
            public void Start()
            {
                using (var manager = new ServerManager(_iisConfigPath))
                {
                    manager.Sites.Add(_name, "http", string.Format("*:{0}:localhost", _port), _path);
                    manager.CommitChanges();
                }
                Process.Start(new ProcessStartInfo
                {
                    FileName = _iisPath,
                    Arguments = _iisArguments,
                    RedirectStandardOutput = true,
                    UseShellExecute = false
                });
                var startTime = DateTime.Now;
                do
                {
                    _iisHandle = _iis.GetRunningProcessForSite(_name, "", _appPool, "");
                    if (_iisHandle != 0) break;
                    if ((DateTime.Now - startTime).Seconds >= 10)
                        throw new TimeoutException("Timeout starting IIS Express.");
                } while (true);
            }
            public void Stop()
            {
                try
                {
                    _iis.StopProcess(_iisHandle);
                }
                finally
                {
                    using (var manager = new ServerManager(_iisConfigPath))
                    {
                        var site = manager.Sites[_name];
                        manager.Sites.Remove(site);
                        manager.CommitChanges();
                    }
                }
            }
        }
