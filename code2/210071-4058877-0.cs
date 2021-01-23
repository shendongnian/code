    string input="20|3d|43|46|3d|46|30|3d|45|38|3d|45|32|3d|45|35|3d|46|32|0d|0a|0d|0a|2e|0d|0a";
    byte[] bytes=input.Split('|').Select(s=>byte.Parse(s, System.Globalization.NumberStyles.HexNumber)).ToArray();
    string text = Encoding.GetEncoding(1251).GetString(bytes);
    StringBuilder text2=new StringBuilder();
    for(int i=0;i<text.Length;i++)
    {
      if (text[i]=='=')
      {
        string hex=text[i+1].ToString()+text[i+2].ToString();
    	byte b=byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);
    
        text2.Append(Encoding.GetEncoding(1251).GetString(new byte[]{b}));
    	i+=2;
      }
      else
      {
      	text2.Append(text[i]);
      }
    }
