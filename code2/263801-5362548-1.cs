    int Year, DayOfMonth;
    string Month;
    string[] Months = new string[] {"ينایر","فبرایر","مارس","ابریل","مایو",...};//these texts are writen with persian keyboard,change the ی  with ي ,its really hard with my keymap
    string[] Splits = Input.Split(" ");
    foreach(string Split in Splits)
    {
        if(Months.Contains(Split))
        {
            Month = Months.IndexOf(Split);
        }
        else
        {
            int Number;
            if(int.TryParse(Split, out Number))
            {
                if(Number<32)
                {
                    DayOfMonth=Number;
                }
                else
                {
                    Year=Number;
                }
            }
        }
    }
