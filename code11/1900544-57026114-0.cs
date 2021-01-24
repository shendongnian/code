        MyFilteredList.Clear();
       foreach(string s in MyItems)
       {
         if(SearchText==null||s.Toupper().Contains(SearchText.ToUpper())
           { 
                  MyFilteredList.Add(s);
            }
        }
    }
