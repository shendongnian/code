    foreach (var line in theList)
    {
        if (!(line.Time.Equals("0")))
            addToDataBase.Add(line.PkgStyle + " " + line.PD + " " + line.Feeder + " " + line.Vision + " " + line.Speed + " " + line.Machine + " " + line.Width + " " + line.Time);
    }
    using (StreamWriter outFile = new StreamWriter(openDataBaseFile.FileName, true))
    {
        outFile.WriteLine();
        foreach (var item in addToDataBaseList)
            outfile.WriteLine(item);
    }
