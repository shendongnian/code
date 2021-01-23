    string EllipsisString = "..."; // you could also just set this as the unicode ellipsis char if that displays properly
    
    private string FitText(string s)
    {
        bool WidthFound = true;
        string TestString = s;
        string StringToReturn = s;
    
        int width = (TextRenderer.MeasureText(s, titleFont)).Width;
        if (width > mailList.Width)
        {
            WidthFound = false;
            for (int i=1; i < s.Length; ++i)
            {
               TestString = s.Substring(0, s.Length - i) + Ellipsis;
               width = (TextRenderer.MeasureText(TestString, titleFont)).Width;
               
               if (width <= mailList.Width)
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
