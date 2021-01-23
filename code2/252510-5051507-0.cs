    using (FileStream sw = File.Create("D:\\Test.bin"))
    {
         BinaryFormatter bf = new BinaryFormatter();
         bf.Serialize(sw, DateTime.Now);
    }
    using (FileStream sw = File.Open("D:\\Test.bin", FileMode.Open))
    {
         BinaryFormatter bf = new BinaryFormatter();
         DateTime dt2 = (DateTime)bf.Deserialize(sw);
    }
