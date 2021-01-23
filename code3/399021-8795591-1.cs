    static class Extensions
    {
        public static string Path(this XElement element)
        {
            XElement tmp = element;
            string path = string.Empty;
            while (tmp != null)
            {
                path = "/" + tmp.Name + path;
                tmp = tmp.Parent;
            }
            return path;
        }
    }
