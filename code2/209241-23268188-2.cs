            [TestCaseSource("GetDataFromCSV2")]
        public int TestDataFromCSV2(int num1, int num2)
        {
            return num1 + num2;
        }
        private IEnumerable GetDataFromCSV2()
        {
            CsvReader reader = new CsvReader(path);
            while (reader.Next())
            {
                int column1 = int.Parse(reader[0]);
                int column2 = int.Parse(reader[1]);
                int column3 = int.Parse(reader[2]);
                yield return new TestCaseData(column1, column2).Returns(column3);
            }
        }
