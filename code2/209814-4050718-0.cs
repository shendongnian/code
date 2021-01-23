    public class MyCollection
        {
            IList<string> MyList { get; set; }
    
            public event EventHandler<StringEventArgs> OnAdded;
            public event EventHandler<StringEventArgs> OnRemoved;
    
            public MyCollection()
            {
                MyList = new List<string>();
            }
    
            public void Add(string s)
            {
                MyList.Add(s);
    
                if (OnAdded != null)
                    OnAdded(this, new StringEventArgs() { StringAddedOrRemoved = s });
            }
    
            public void Remove(string s)
            {
                MyList.Remove(s);
                if (OnRemoved != null)
                    OnRemoved(this, new StringEventArgs() { StringAddedOrRemoved = s });
            }
        }
