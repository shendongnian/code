        public static void SaveAsUTF8WithoutByteOrderMark(string fileName)
        {
            SaveAsUTF8WithoutByteOrderMark(fileName, null);
        }
        public static void SaveAsUTF8WithoutByteOrderMark(string fileName, Encoding encoding)
        {
            if (fileName == null)
                throw new ArgumentNullException("fileName");
            if (encoding == null)
            {
                encoding = Encoding.Default;
            }
            File.WriteAllText(fileName, File.ReadAllText(fileName, encoding), new UTF8Encoding(false));
        }
