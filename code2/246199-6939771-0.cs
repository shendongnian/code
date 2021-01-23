    public static class Obj
    {
      //....
      public static string FtCad(string ci)
      {
        return Regex.Replace(ci, @"[\r\n\\'""]", @"\$0");
      }
      
    }
    //And when need:
    string fieldcad = Obj.FtCad(Text1.text);
