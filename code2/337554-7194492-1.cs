      var contents = 
    @"FILE001DETAILCOUNT002
    BATCH01
    DETAIL001FOO
    BATCH02
    DETAIL001BAR";
      // foreach batch....
      foreach (Match match in Regex.Matches (contents, @"BATCH\d+\s+(?:(?!BATCH\d+).*\s*)+"))
      {
         Console.WriteLine ("==============\r\nFile\r\n================");
         int batchNum = 1;
         int detailNum = 1;
         StringBuilder temp = new StringBuilder ();
         TextWriter file = new StringWriter (temp);
         // Your file here instead of my stringBuilder/StringWriter
         string batchText = match.Value;
         int count = Regex.Matches (batchText, @"^DETAIL\d+", RegexOptions.Multiline).Count;
         file.WriteLine ("FILE001DETAILCOUNT{0:000}", count);
         string newText = Regex.Replace (batchText, @"(?<=^BATCH)\d+", batchNum.ToString ("000"), RegexOptions.Multiline);
         newText = Regex.Replace (
            newText, 
            @"(?<=^DETAIL)\d+", 
            m => (detailNum++).ToString ("000"), // replacement (evaluated for each match)
            RegexOptions.Multiline);
         file.Write (newText);
         Console.WriteLine (temp.ToString ());
      }
