    public class ItemDataBoundArgs: EventArgs
    {
       public object Item;
    }
    public class MyListBox: ListBox
    {
        public event EventHandler ItemDataBound;
        protected override void OnDataBinding(EventArgs e)
        {
           base.OnDataBinding(e);
           if (ItemDataBound != null)
           {
               foreach (var item in (IEnumerable)DataSource)
               {
                    var e= new ItemDataBoundArgs();
                    e.Item=item;
                    ItemDataBound(this,e);
                }
            }
        }
    }
