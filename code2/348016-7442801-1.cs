    int minAge = 18, maxAge=20;
    DateTime convertedMinDob = DateTime.Now.AddYears(-minAge);
    DateTime convertedMaxDob = DateTime.Now.AddYears(-maxAge);
    Console.WriteLine(convertedMinDob.ToString() + " " + convertedMaxDob.ToString());
    string strDate = "1/1/1995";
    DateTime actualDate = DateTime.Parse(strDate);
    bool valid = actualDate >= convertedMaxDob && actualDate <= convertedMinDob;
            
    Console.WriteLine(valid? "In range": "Out of range");
