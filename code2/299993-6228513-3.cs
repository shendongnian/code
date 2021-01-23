    public class SortableGenericCollection<T> : BindingList<T>
    {
      IByColumnComparer GenericComparer = null; 
    
      public SortableGenericCollection(IByColumnComparer SortingComparer)
      {
         GenericComparer = SortingComparer;
      }
    
    
      protected override bool SupportsSortingCore
      {
         get
         {
            return true;
         }
      }
    
      protected override bool IsSortedCore
      {
         get
         {
            for (int i = 0; i < Items.Count - 1; ++i)
            {
               T lhs = Items[i];
               T rhs = Items[i + 1];
               PropertyDescriptor property = SortPropertyCore;
               if (property != null)
               {
                  object lhsValue = lhs == null ? null :
                  property.GetValue(lhs);
                  object rhsValue = rhs == null ? null :
                  property.GetValue(rhs);
                  int result;
                  if (lhsValue == null)
                  {
                     result = -1;
                  }
                  else if (rhsValue == null)
                  {
                     result = 1;
                  }
                  else
                  {
                     result = GenericComparer.Compare(lhs, rhs); 
                  }
                  if (result >= 0)
                  {
                     return false;
                  }
               }
            }
            return true;
         }
      }
    
      private ListSortDirection sortDirection;
      protected override ListSortDirection SortDirectionCore
      {
         get
         {
            return sortDirection;
         }
      }
    
      private PropertyDescriptor sortProperty;
      protected override PropertyDescriptor SortPropertyCore
      {
         get
         {
            return sortProperty;
         }
      }
    
      protected override void ApplySortCore(PropertyDescriptor prop,
      ListSortDirection direction)
      {
         sortProperty = prop;
         sortDirection = direction;
    
         GenericComparer.SortColumn = prop.Name;
         GenericComparer.SortDescending = direction == ListSortDirection.Descending ? true : false;
    
         List<T> list = (List<T>)Items;
         list.Sort(delegate(T lhs, T rhs)
         {
            if (sortProperty != null)
            {
               object lhsValue = lhs == null ? null :
               sortProperty.GetValue(lhs);
               object rhsValue = rhs == null ? null :
               sortProperty.GetValue(rhs);
               int result;
               if (lhsValue == null)
               {
                  result = -1;
               }
               else if (rhsValue == null)
               {
                  result = 1;
               }
               else
               {
                  result = GenericComparer.Compare(lhs, rhs);
               }
               return result;
            }
            else
            {
               return 0;
            }
         });
      }
    
      protected override void RemoveSortCore()
      {
         sortDirection = ListSortDirection.Ascending;
         sortProperty = null;
      }
    }
