    static public class Deployment
    {
        public static readonly string WebSite = @"....";
        public const string version_filename = "version";
        static string get_version(Stream stream)
        {
            var lines = new List<string>();
            var reader = new StreamReader(stream);
            while (true)
            {
                var s = reader.ReadLine();
                if (s == null)
                    break;
                lines.Add(s);
            }
            stream.Close();
            return lines.Join(CHAR.LineFeed).Trim();
        }
        static string GetWebVersionInfo()
        {
            try
            {
                var client = new WebClient();
                using (var stream = client.OpenRead(WebSite + version_filename))
                    return get_version(stream);
            }
            catch
            {
                return null;
            }
        }
        static string GetLocalVersionInfo()
        {
            try
            {
                using (var stream = new FileStream(System.IO.Path.GetDirectoryName(ProgramInfo.FilePath) +
                                                   System.IO.Path.DirectorySeparatorChar +
                                                   version_filename, FileMode.Open, FileAccess.Read))
                    return get_version(stream);
            }
            catch
            {
                return null;
            }
        }
        static public bool IsNewVersionAvailable()
        {
            var web_version = Deployment.GetWebVersionInfo();
            var exe_version = Deployment.GetLocalVersionInfo(); 
            return (web_version != null && (exe_version == null || exe_version.Comparison(web_version) == CompareEnum.Less));
        }
    }
