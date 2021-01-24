    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleDemo
    {
        public class Program
        {
            public static void Main()
            {
                var testData = new MyCls(MY_SP_Result.GetData()).MyData;
                var i = 0;
                var j = 0;
                Console.WriteLine("Data\n");
                foreach (var td in testData)
                {
                    Console.WriteLine($"--> [{i++}]");
                    Console.WriteLine($"--> {td.TEST_VAL}");
                    Console.WriteLine("\tID\tYEAR\tVALUE\tTEST_VALUE");
                    Console.WriteLine("\t---------------------------------");
                    foreach (var tv in td.Data)
                        Console.WriteLine($"\t[{j++}]\t{tv.ID}\t{tv.YEAR}\t{tv.VALUE}\t{tv.TEST_VALUE}");
                    Console.WriteLine();
                    j = 0;
                }
                Console.ReadKey();
            }
        }
        public class TestData
        {
            public int TEST_VAL { get; set; }
            public List<MY_SP_Result> Data { get; set; }
        }
        public class MyCls
        {
            public List<TestData> MyData { get; set; }
            public MyCls(List<MY_SP_Result> data)
            {
                var testValues = data.Select(d => d.TEST_VALUE).Distinct();
                MyData = testValues.Select(tv => new TestData
                {
                    TEST_VAL = tv,
                    Data = data.Where(d => d.TEST_VALUE == tv).ToList()
                }).ToList();
            }
        }
        public class MY_SP_Result
        {
            public int ID { get; set; }
            public int YEAR { get; set; }
            public int VALUE { get; set; }
            public int TEST_VALUE { get; set; }
            public static List<MY_SP_Result> GetData()
            {
                return new List<MY_SP_Result>
                {
                    new MY_SP_Result { ID = 1, YEAR = 2019, VALUE = 78, TEST_VALUE = 3 },
                    new MY_SP_Result { ID = 1, YEAR = 2020, VALUE = 12, TEST_VALUE = 3 },
                    new MY_SP_Result { ID = 1, YEAR = 2021, VALUE = 56, TEST_VALUE = 3 },
                    new MY_SP_Result { ID = 2, YEAR = 2019, VALUE = 23, TEST_VALUE = 2 },
                    new MY_SP_Result { ID = 2, YEAR = 2020, VALUE = 89, TEST_VALUE = 2 },
                    new MY_SP_Result { ID = 2, YEAR = 2021, VALUE = 34, TEST_VALUE = 2 },
                };
            }
        }
    }
