    string codePoints = "\u0641 \u064A \u0649 \u0642 \u0625";
    
    UnicodeEncoding uEnc = new UnicodeEncoding();
    byte[] bytesToWrite = uEnc.GetBytes(codePoints);
    System.IO.File.WriteAllBytes(@"yadda.txt", bytesToWrite);
    byte[] readBytes = System.IO.File.ReadAllBytes(@"yadda.txt");
    string val = uEnc.GetString(readBytes);
