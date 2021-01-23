     List<MyListItem> myList = new List<MyListItem>();
    
            getsomedata(myList); //populate list
    
            myList.Sort((a, b) => (a.date + a.Hour.ToString("00")).CompareTo(b.date + b.Hour.ToString("00")));
        
        private void getsomedata(List<MyListItem> items)
        {
            for (int i = 1; i < 30; i += 3)
            {
                items.Add(new MyListItem("2010-12-05", i));
            }
            for (int i = 2; i < 30; i += 3)
            {
                items.Add(new MyListItem("2010-12-05", i));
            }
        }
    
        class MyListItem
        {
            public MyListItem(string date, int hour) { this.date = date; this.Hour = hour; }
            public string date; //date in the format "2010-12-05"
            public int Hour;    //hour of day as an int
        }
