    public bool AllSame(IEnumerable<Item> items) 
    {    
        object value;
        
        foreach (Item item in items)
        {
            if(value == null)
            {
                value = item.MyMember;
                continue;
            }
            if(!item.MyMember.Equals(value))
            {
                 return false;
            }
        }
}
