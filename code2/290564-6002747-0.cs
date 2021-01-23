    public static class FileExtension
    {
        public static string Extension(this string filename)
        {
            int index = filename.LastIndexOf('.');
            if(index > 0)
                return filename.Substring(index, filename.length - index);
    
            return filename;
        }
    }
