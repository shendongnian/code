    string stringData;
    double d;
    int i;
    streamReader = new StreamReader(potato.txt);
    while (streamReader.Peek() > 0)
    {
       data = streamReader.ReadLine();
       
       if (int.TryParse(data, out i) 
       {       
           Console.WriteLine("{0,8} {1,15}", i, i.GetType());
       }
       else if (double.TryParse(data, out d) 
       {       
           Console.WriteLine("{0,8} {1,15}", d, d.GetType());
       }
       else Console.WriteLine("{0,8} {1,15}", data, data.GetType());
    }
