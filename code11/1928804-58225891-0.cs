string[] lines = { name, FirstBlock, MonIstem, WedIstem, ThridBlock, FourthBlock, "Design Time", SixthBlock, TueIstem, ThurIstem, EighthBlock, NinthBlock, "Design Time", FriIstem };
string[] names = { "name", "FirstBlock", "MonIstem", "WedIstem", "ThirdBlock", "FourthBlock", "Design Time", "SixthBlock", "TueIstem", "ThurIstem", "EightBlock", "NinthBlock", "Design Time", "FriIstem", };
        foreach (string TXTname in names)
        {
                Console.WriteLine($"Saving {TXTname}");
            
            foreach (string line in lines)
            {
                string getNameOfVar = nameof(line);
                using (FileStream bs = File.OpenWrite($@"C:\Users\gn193755\Documents\{TXTname}.txt"))
                {
                    byte[] thing = new UTF8Encoding(true).GetBytes(line);
                    bs.Write(thing, 0, thing.Length);
                }
            }
        }
Try using the above code
