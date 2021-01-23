     public void PrintAllFiles()
        {
            DirectoryInfo obj = new DirectoryInfo("E:\\");
            foreach (var k in obj.GetFiles())
            {
                Console.WriteLine(k.FullName);
            }
        }
