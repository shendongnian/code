    ArrayList list = new ArrayList();
    list.Add(1);
    list.Add("Hello World");
    list.Add(DateTime.Now);
    
    BinaryFormatter bf = new BinaryFormatter();
    
    FileStream fsout = new FileStream("file.dat", FileMode.Create);
    bf.Serialize(fsout, list);
    fsout.Close();
    
    FileStream fsin = new FileStream("file.dat", FileMode.Open);
    ArrayList list2 = (ArrayList)bf.Deserialize(fsin);
    fsin.Close();
    
    foreach (object o in list2)
       Console.WriteLine(o.GetType());
