    private bool IsAdding { get; set; }
    public void AddNewItem(object item)
    {
        if (item == null)
        {
            throw new Exception("Cannot add null item."); // little bit of contracting never hurts
        }
        collection.Add(item);
        IsAdding = true;
        ItemIndex = collection.Count - 1; //I'm just making assumptions about this piece but it is not important how you decide what your index is to answer the question
                
        if (OnNewItem != null)
        {
           OnNewItem(this, EventArgs.Empty); 
        }
    }
    
    public int ItemIndex
    {
       get { return m_itemIndex; }
       set
       {
           m_itemIndex = value;
           if (!IsAdding && OnScroll != null) //won't double fire event thanks to IsAdding
           {
               OnScroll(this, EventArgs.Empty);
           }
           IsAdding = false; //need to reset it
       }
    }
