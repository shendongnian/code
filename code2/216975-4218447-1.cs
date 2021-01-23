    using System;
    using System.Collections.Generic;
    using System.IO;
    namespace ConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args)
        {
            List<Data> items = new List<Data>();
            using (StreamReader reader = new StreamReader("C:\\chedberg\\combine.txt"))
            {
                string line;
                string[] split;
                string name;
                int count;
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        split = line.Split('|');
                        name = split[0];
                        if(Int32.TryParse(split[1],out count))
                            items.Add(new Data() { Name = name, Count = count });
                    }
                }
                List<Data> combinedItems = new List<Data>();
                items.ForEach(item =>
                                  {
                                      if (!combinedItems.Exists(combinedItem => combinedItem.Name == item.Name)) 
                                          combinedItems.Add(new Data(){Name = item.Name, Count = item.Count});
                                      else
                                      {
                                          combinedItems.Find(combinedItem => combinedItem.Name == item.Name).Count += item.Count;
                                      }
                                  });
                using (StreamWriter writer = new StreamWriter("C:\\chedberg\\combine_out.txt"))
                {
                    combinedItems.ForEach(item => writer.WriteLine(String.Format("{0}|{1}",item.Name,item.Count)));
                    writer.Flush();
                }
            }
        }
        public class Data
        {
            public string Name { get; set; }
            public int Count { get; set; }
        }
    }
}
