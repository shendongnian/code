    using System;
    using System.IO;
    namespace _5893408
    {
        class Program
        {
            static void Main(string[] args)
            {
                Random rand = new Random();
                var futureTime = DateTime.Now.AddSeconds(60);
                while (DateTime.Now < futureTime)
                    Console.WriteLine(GetNextNumber(rand));
            }
    
            public static int GetNextNumber(Random rand)
            {
                var now = DateTime.Now;
                string filePath = @"C:\num.txt";
                FileStream fileStream = null;
                while (fileStream == null)
                {
                    try { fileStream = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None); }
                    catch { }
                }
                using (fileStream)
                {
                    DateTime date;
                    int prevNum;
                    if (fileStream.Length == 0)
                    {
                        date = now;
                        prevNum = rand.Next(100000, 999999);
                    }
                    else
                    {
                        var reader = new StreamReader(fileStream);
                        {
                            date = DateTime.Parse(reader.ReadLine());
                            prevNum = int.Parse(reader.ReadLine());
                        }
                        if (date.DayOfYear != now.DayOfYear)
                            prevNum = rand.Next(100000, 999999);
                    }
                    int nextNum = prevNum + rand.Next(10, 1000);
                    fileStream.Seek(0, SeekOrigin.Begin);
                    using (var writer = new StreamWriter(fileStream))
                    {
                        writer.WriteLine(now);
                        writer.WriteLine(nextNum);
                    }
                    return nextNum;
                }
            }
        }
    }
