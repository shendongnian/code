    string pattern = String.Empty;
    //pattern =  @"#x((10?|[2-F])FFF[EF]|FDD[0-9A-F]|7F|8[0-46-9A-F]9[0-9A-F])"; //XML 1.0
    pattern =  @"#x((10?|[2-F])FFF[EF]|FDD[0-9A-F]|[19][0-9A-F]|7F|8[0-46-9A-F]|0?[1-8BCEF])"; // XML 1.1
    Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
    if (regex.IsMatch(sString))
    {
       sString = regex.Replace(sString, String.Empty);
       File.WriteAllText(sString, sString, Encoding.UTF8);
    }
    return sString;
