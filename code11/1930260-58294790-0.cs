    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string INPUT_FILENAME = @"c:\temp\test.txt";
            const string OUTPUT_FILENAME = @"c:\temp\test1.txt";
            static void Main(string[] args)
            {
                List<Column> columns = new List<Column>() {
                    new Column() { name = "Type", type = typeof(string), width = 5},
                    new Column() { name = "TypeWeb", type = typeof(string), width = 9},
                    new Column() { name = "ValueToPay", type = typeof(int), width = 18},
                    new Column() { name = "Date", type = typeof(DateTime), width = 8, inputFormat = "yyyyMMdd", outputFormat = "yyyy/MM/dd"}
                };
                List<List<object>> data = FixedWidth.ReadFile(INPUT_FILENAME, columns);
                FixedWidth.WriteFile(OUTPUT_FILENAME, data, columns);
            }
        }
        public class FixedWidth
        {
            public static List<List<object>> ReadFile(string filename,List<Column> columns)
            {
                List<List<object>> data = new List<List<object>>();
                string line = "";
                using (StreamReader reader = new StreamReader(filename))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        List<object> newLine = new List<object>();
                        data.Add(newLine);
                        int startPos = 0;
                        foreach (Column column in columns)
                        {
                            string col = line.Substring(startPos, column.width);
                            switch (column.type.ToString())
                            {
                                case "System.String" :
                                    newLine.Add(col.Trim());
                                    break;
                                case "System.Int32" :
                                    newLine.Add(int.Parse(col));
                                    break;
                                case "System.DateTime":
                                    newLine.Add(DateTime.ParseExact(col, column.inputFormat, CultureInfo.InvariantCulture));
                                    break;
                                default:
                                   break;
                            }
                            startPos += column.width;
                        }
                    }
                }
                return data;
            }
            public static List<List<object>> WriteFile(string filename, List<List<object>> data,  List<Column> columns)
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    int rowCount = 1;
                    foreach(List<object> row in data)
                    {
                        string line = string.Format("{0}> ", rowCount.ToString());
                        for (int index = 0; index < columns.Count; index++)
                        {
                            line += string.Format("{0}:", columns[index].name);
                            switch (columns[index].type.ToString())
                            {
                                case "System.DateTime":
                                    line += ((DateTime)row[index]).ToString(columns[index].outputFormat).PadRight(columns[index].width);
                                    break;
                                default:
                                    line += row[index].ToString().PadRight(columns[index].width);
                                    break;
                            }
                        }
                        writer.WriteLine("{0}<",line);
                        rowCount++;
                    }
                }
                return data;
            }
        }
        public class Column
        {
            public string name { get; set; }
            public Type type { get; set; }
            public int width { get; set; }
            public string inputFormat { get; set; }
            public string outputFormat { get; set; }
        }
    }
