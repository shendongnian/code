    List<String> zipCodes = new List<String>();
    zipCodes.Add("00124");
    zipCodes.Add("00123");
    zipCodes.Add("98765");
    zipCodes.Add("12345");
    zipCodes.Add("33333");
    zipCodes.Add("24680");
    
    // zipCodes = zipCodes.Select(z => z.PadLeft(5, '0')).ToList();
    zipCodes.Sort();
    
    for(int i = 0; i < zipCodes.Count; i++)
       Console.WriteLine(zipCodes[i]);
