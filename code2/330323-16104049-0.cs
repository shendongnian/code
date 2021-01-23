    public class ItemGridVM : BaseViewModel
        {
        private Item _item;//an instance of Item class
          public int ItemId
                  {
                      get
                      {
                          return _item.ItemId;
                      }
                      set
                      {
                          _item.ItemId = value;
                          //if you want UI changes : raise PropertyChanged Notification and binding in UI should be Update SourceTrigger:PropertyChanged
                      }
            }
       //Contains Commands :UpdateItem,EditItem,DeleteItem
    }
