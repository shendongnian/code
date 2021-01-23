    public class CsvWriter
    {
        const string path = "myfile.csv";
        static object synch = new Object();
        public void AppendCsv(string newData)
        {
            lock (synch)
            {
                File.AppendAllText(path, newData);
            }
        }
    }
