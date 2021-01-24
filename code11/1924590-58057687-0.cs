    int counter = 0;
    string line;
    // Read the file and display it line by line.  
    System.IO.StreamReader file =
        new System.IO.StreamReader(@"D:\master_email_list.txt");
    while ((line = file.ReadLine()) != null)
    {
        counter++;
        StreamWriter sw = new StreamWriter("D:\\emailFolder\\" + counter.ToString().PadLeft(3, '0') + ".txt");
        sw.Write(line);
        sw.Flush();
        sw.Close();
    }
    file.Close();
    System.Console.ReadLine();
