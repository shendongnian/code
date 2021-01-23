    Record[] rec = new Record[100000]; 
    Class1 cl = new Class1(); 
    Random random = new Random(); 
    int i = 0;
    while (i < 100000) 
    { rec[i].num1 = random.Next(); rec[i].var_set = cl.generateRandomString(2); i++; };
    i = 0;
    using (StreamWriter writer = new StreamWriter("important.txt", true))
        {
            while ( i < 100000)
            {
            writer.Write(rec[i].name);
            writer.Write("   ");
            writer.Write(rec[i].var_set);
            writer.Write("   ");
            writer.Write(rec[i].num1);
            writer.Write("   ");
            writer.Write(rec[i].num2);
            writer.Write("   ");
            writer.Write(rec[i].mult);
            writer.Write("   "); 
            writer.WriteLine(rec[i].rel);
            i++;
            };
        }
