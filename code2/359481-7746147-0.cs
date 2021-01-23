    string final1 = GetMyString("A123949DADWE2ASDASDW");
    string final2 = GetMyString("ASDRWE234DS2334234234");
    string final3 = GetMyString("ZXC234ASD43D33SDF23SDF");
    
    public function GetMyString(string Original)
    {
        string result = Original.Substring(12);
        result = result.Remove(9, 1);
        return result;
    }
