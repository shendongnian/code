    private enum DateComparisonResult
        {
            Earlier = -1,
            Later = 1,
            TheSame = 0
        };
        void comapre()
        {
            DateTime Date1 = new DateTime(2020,10,1);
            DateTime Date2 = new DateTime(2010,10,1);
            DateComparisonResult comparison;
            comparison = (DateComparisonResult)Date1.CompareTo(Date2);
            MessageBox.Show(comparison.ToString());    
        }
        //Output is "later", means date1 is later than date2 
