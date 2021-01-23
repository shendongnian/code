     public void ffg()
        {
            DirectoryInfo obj = new DirectoryInfo("E:\\");
            foreach (var k in obj.GetFiles())
            {
                Console.WriteLine(k.FullName);
            }
        }
