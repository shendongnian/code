    string s = "abc,def,ghi,jkl,mno,,";
            string[] s2 = s.Split(',');
            for (int i = 0; i < s2.Length; i++)
            {
                if (!string.IsNullOrEmpty(s2[i]))
                    Console.WriteLine("{0} Partition FULL",i.ToString());
                else
                    Console.WriteLine("{0} Partition Empty", i.ToString());
            }
            Console.Read();
