    StringBuilder sb2 = new StringBuilder(columns);
    foreach(var data in datas)
    {
        sb2 = sb.AppendRight(data.ID.ToString(), data.PatName);
    }
    Console.WriteLine(sb.ToString());
    Console.ReadLine();
