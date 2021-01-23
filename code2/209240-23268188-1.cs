            [TestCaseSource("GetDataFromCSV")]
        public void TestDataFromCSV(int num1,int num2,int num3)
        {
            Assert.AreEqual(num1 + num2 ,num3);
        }
        private IEnumerable<int[]> GetDataFromCSV()
        {
            CsvReader reader = new CsvReader(path);
            while (reader.Next())
            {
                int column1 = int.Parse(reader[0]);
                int column2 = int.Parse(reader[1]);
                int column3 = int.Parse(reader[2]);
                yield return new int[] { column1, column2, column3 };
            }
        }
		
		
    public class CsvReader : IDisposable
    {
        private string path;
        private string[] currentData;
        private StreamReader reader;
        public CsvReader(string path)
        {
            if (!File.Exists(path)) throw new InvalidOperationException("path does not exist");
            this.path = path;
            Initialize();
        }
        private void Initialize()
        {
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            reader = new StreamReader(stream);
        }
        public bool Next()
        {
            string current = null;
            if ((current = reader.ReadLine()) == null) return false;
            currentData = current.Split(',');
            return true;
        }
        public string this[int index]
        {
            get { return currentData[index]; }
        }
        public void Dispose()
        {
            reader.Close();
        }
    }
