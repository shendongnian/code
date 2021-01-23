    using System.Text.RegularExpressions;
    
    /*
    00123 => 123
    00000 => 0
    00000a => 0a
    00001a => 1a
    00001a => 1a
    0000132423423424565443546546356546454654633333a => 132423423424565443546546356546454654633333a
    */
    
    Regex removeLeadingZeroesReg = new Regex(@"^0+(?=\d)");
    var strs = new string[]
    {
        "00123",
        "00000",
        "00000a",
        "00001a",
        "00001a",
        "0000132423423424565443546546356546454654633333a",
    };
    foreach (string str in strs)
    {
        Debug.Print(string.Format("{0} => {1}", str, removeLeadingZeroesReg.Replace(str, "")));
    }
