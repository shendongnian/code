    public void CreateUsernameList(string targetfile,string outputfile)
    {
        File.WriteAllLines(
            outputfile,
            File.ReadLines(targetfile)
                .Select(line => 
                 {
                     var Split = line.Split(new char[] { '@' });
                     var Split1 = line.Split(new char[] { ':' });
                     return Split[0] + ":" + Split1[1];
                 }
            )
        ); 
    }
