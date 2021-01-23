     public List<Item> GetItemsByFilter(BaseFilter filter, 
                       QueryComplete query, SortByBuilder sort)
     {
       var resultItems = new List<Item>();
       var cursor = Db.Data.FindAs<BsonItem>(query);
    
       cursor.SetSortOrder(sort);
       if (filter.IsNeedPaging)
       {
         cursor.SetSkip(filter.Skip).SetLimit(filter.Take);
         filter.TotalCount = cursor.Count();
       }
    
       resultItems.AddRange(cursor);
    
       return resultItems;
     }
 
     public class BaseFilter
     {
       private int _itemsPerPage = 10;
       private int _skip = 0;
       private int _currentPage = 1;
    
       public BaseFilter()
       {
         IsNeedPaging = true;
       }
    
       public int Skip
       {
         get
         {
           if (_skip == 0)
             _skip = (CurrentPage - 1) * _itemsPerPage;
           return _skip;
         }
         set
         {
           _skip = value;
         }
       }
    
       public int Take
       {
         get
          {
             return _itemsPerPage;
          }
         set
          {
            _itemsPerPage = value;
          }
        }
    
        public bool IsNeedPaging { get; set; }
    
        public int TotalCount { get; set; }
    
        public int CurrentPage
        {
          get
            {
               return _currentPage;
            }
          set
            {
              _currentPage = value;
            }
        }
    
        public int ItemsPerPage
        {
          get
            {
              return _itemsPerPage;
            }
          set
            {
              _itemsPerPage = value;
            }
         }
    
         public int TotalPagesCount
         {
           get
             {
               return TotalCount / ItemsPerPage + 
                                ((TotalCount % ItemsPerPage > 0) ? 1 : 0);
             }
         }
       }
