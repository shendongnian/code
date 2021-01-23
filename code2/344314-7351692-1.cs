    class Item 
    {
         public event Action<Item, string> DataChanged;
        
         public int Id {get; private set;}
         public string Ref1 { get { return _ref1; } set { _ref1 = value; OnDataChanged("ref1"); }
         public string Ref2 { get { return _ref2; } set { _ref2 = value; OnDataChanged("ref2"); }
         public string Ref3 { get { return _ref3; } set { _ref3 = value; OnDataChanged("ref3"); }
       .....
       protected virtual void OnDataChanged(string field)
       {
           if (DataChanged!=null) DataChanged(this, field);
       }
       public void UpdateFieldsFrom(Item item)
       {
           this._ref1 = item._ref1;
           this._ref2 = item._ref2;
           this._ref3 = item._ref3;
           .....
       }
    } 
    class ItemCollection
    {
         Dictionary<int, Item> Items; 
         
         public void Add(Item item)
         {
              Items.Add(item.Id, item);
              Item.DataChanged+= OnItemDataChanged;
         }
         public void Remove(Item item)
         {
              Items.Remove(item.Id);
              Item.DataChanged-= OnItemDataChanged;
         }
         void OnItemDataChanged(Item sender, string field)
         {
              List<Item> result = Items.Where(i => i.Ref1 == sender.Ref1);
              
              foreach (Item item in result)
              {
                  item.UpdateFieldsFrom(sender); 
              }
         }
    }
    
