    string EllipsisString = "..."; // you could also just set this as the unicode ellipsis char if that displays properly
    
    private string FitText(string s)
    {
        bool WidthFound = false;
        string TestString = s;
        string StringToReturn = s;
    
        int width = (TextRenderer.MeasureText(s, titleFont)).Width;
        if (width > mailList.Width)
        {
            for (int i=1; i < s.Length; ++i)
            {
               TestString = s.Substring(0, Length - i);
               width = (TextRenderer.MeasureText(TestString + Ellipsis, titleFont)).Width;
               
               if (width > mailList.Width)
               {
                  StringToReturn = TestString;
                  WidthFound = true;
                  break;
               }
            }
        }
    
        if (WidthFound)
            return StringToReturn;
        else
            return Ellipsis;
    }
