    public sealed class MultiKeyedObject : IHasKeyComparator<MultiKeyedObject> {
       public int ID1 { get; set; }
       public string ID2 { get; set; }       
       readonly Expression<Func<MultiKeyedObject, bool>> mKeyComparator;
       public Expression<Func<MultiKeyedObject, bool>> KeyComparator {
          get { return mKeyComparator; }
       }
       public MultiKeyedObject() {
          mKeyComparator = other => other.ID1 == ID1 && other.ID2 == ID2;
       }
    }
