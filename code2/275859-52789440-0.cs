    List<ObjectC> _list_DF_BW_ANB = new List<ObjectC>();    
    List<ObjectA> _listA = new List<ObjectA>();
    List<ObjectB> _listB = new List<ObjectB>();
    foreach (var itemB in _listB )
    {     
           var flat = 0;
               foreach(var itemA in _listA )
               {
                   if(itemA.ProductId==itemB.ProductId)
                   {
                             flat = 1;
                             break;
                   }
               }
           if (flat == 0)
           {
                _list_DF_BW_ANB.Add(itemB);
          }
     }
