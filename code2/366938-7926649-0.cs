        /* Open OEM File*/ 
    FileStream f1 = new FileStream(@"..\..\Datas\TestOEM.txt",FileMode.Open);
    StreamReader sw1 = new StreamReader(f1,
        Encoding.GetEncoding(CultureInfo.CurrentCulture.TextInfo.OEMCodePage));
    string a = sw1.ReadLine();
    Console.WriteLine(a);
    sw1.Close();
    f1.Close();
      /* Open Unicode file */
    FileStream f2 = new FileStream(@"..\..\Datas\TestUNICODE.txt",FileMode.Open);
    StreamReader sw2 = new StreamReader(f2,Encoding.Unicode);
    string b = sw2.ReadLine();
    Console.WriteLine(b);
    sw2.Close();
    f2.Close();
      /* Open ANSI file */
    FileStream f3 = new FileStream(@"..\..\Datas\TestANSI.txt",FileMode.Open);
    StreamReader sw3 = new StreamReader(f3,Encoding.Default);
    string c = sw3.ReadLine();
    Console.WriteLine(c);
    sw3.Close();
    f3.Close();
