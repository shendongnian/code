        private static void TestDictionaryLimit()
        {
            int intCnt = 0;
            Dictionary<long, string> dItems = new Dictionary<long, string>();
            Console.WriteLine("Total number of iterations = {0}", long.MaxValue);
            Console.WriteLine("....");
            for (long lngCnt = 0; lngCnt < long.MaxValue; lngCnt++)
            {
                if (lngCnt < 11950020)
                    dItems.Add(lngCnt, lngCnt.ToString());
                else
                    break;
                if ((lngCnt % 100000).Equals(0))
                    Console.Write(intCnt++);
            }
            Console.WriteLine("Completed..");
            Console.WriteLine("{0} number of items in dictionary", dItems.Count);
        }
