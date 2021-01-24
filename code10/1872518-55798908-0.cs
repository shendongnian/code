    public class FileRowReader
    {
        public string[] ReadRows(string filename)
        {
            StreamReader s = new StreamReader(filename);
            string fileContents = s.ReadToEnd();
            int removeHeader = fileContents.IndexOf('\n');
            string contentsNoHeader = fileContents.Substring(removeHeader);
            string contentsFixed = contentsNoHeader.Replace("'", "''");
            string delim = "\n";
            return contentsFixed.Split(delim.ToCharArray());
        }
    }
