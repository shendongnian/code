    using System.Linq; 
    
    string StrCheck = "abcd123";
    check the string has characters --->  StrCheck.Any(char.IsLetter) 
    check the string has numbers   --->   StrCheck.Any(char.IsDigit)
    if (StrCheck.Any(char.IsLetter) && StrCheck.Any(char.IsDigit))
    {
    //statement goes here.....
    }
    sorry for the late reply ...
