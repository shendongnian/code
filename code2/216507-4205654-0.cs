     public class ProductList
    {
       public string ProductID {get;set;}
       public int Amount {get;set;}
    }
    public class MyBindingList<T>:BindingList<T> where T:ProductList
    {
        protected override void InsertItem(int index, T item)
        {
            var tempList = Items.Where(x => x.ProductID == item.ProductID);
            if (tempList.Count() > 0)
            {
               T itemTemp = tempList.FirstOrDefault();
               itemTemp.Amount += item.Amount;
            
                
            }
            else
            {
                if (index > base.Items.Count)
                {
                    base.InsertItem(index-1, item);
                }
                else
                    base.InsertItem(index, item);
               
            }
            
        }
        public void InsertIntoMyList(int index, T item)
        {
            InsertItem(index, item);
        }
        
    
    }
