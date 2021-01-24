    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string INPUT_CSV_FILENAME = @"c:\temp\test.csv";
            const string OUTPUT_CSV_FILENAME = @"c:\temp\test1.csv";
            const string OUTPUT_STATISTICS_FILENAME = @"c:\temp\statistic.txt";
            static void Main(string[] args)
            {
                Data data = new Data(INPUT_CSV_FILENAME);
                data.WriteStatistics(OUTPUT_STATISTICS_FILENAME);
                data.WriteCSV(OUTPUT_CSV_FILENAME);
            }
        }
        class Data
        {
            public static List<Data> datas = new List<Data>();
            public string name;
            public int length;
            public string date;
            public string province;
            public Data() { }
            public Data(string filename)
            {
                StreamReader reader = new StreamReader(filename);
                string line = "";
                int rowCount = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (line.Length > 0)
                    {
                        string[] splitArray = line.Split(new char[] { ';' });
                        if (++rowCount > 1)
                        {
                            string[] splitProvidence = splitArray[3].Split(new char[] { '-' });
                            foreach (string providence in splitProvidence)
                            {
                                Data newRow = new Data();
                                Data.datas.Add(newRow);
                                newRow.name = splitArray[0];
                                newRow.length = int.Parse(splitArray[1]);
                                newRow.date = splitArray[2];
                                newRow.province = providence;
                            }
                        }
                    }
                }
            }
            public void WriteStatistics(string filename)
            {
                StreamWriter writer = new StreamWriter(filename);
                var groups = datas.GroupBy(x => x.province).OrderByDescending(x => x.Count()).ToList();
                foreach (var group in groups)
                {
                    writer.WriteLine("{0} - {1}", group.Key, group.Count());
                }
                writer.Flush();
                writer.Close();
            }
            public void WriteCSV(string filename)
            {
                StreamWriter writer = new StreamWriter(filename);
                string header = string.Join(";", new string[] { "name","length","date","province"});
                writer.WriteLine(header);
                foreach (Data data in datas)
                {
                    writer.WriteLine(string.Join(";",new string[] {
                        data.name,
                        data.length.ToString(),
                        data.date,
                        data.province
                    }));
                }
                writer.Flush();
                writer.Close();
            }
        }
    }
