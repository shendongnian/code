    public class FasterComparingList<T>: IList<T>, IList, ... 
        /// whatever you need to implement
    {
       // Implement your interfaces against InnerList
       // Any methods that change members of the list need to
       // set _LongHash=null to force it to be regenerated
       public List<T> InnerList { ... lazy load a List }
       public int GetHashCode()
       {
           if (_LongHash==null) {
               _LongHash=GetLongHash();
           }
           return (int)_LongHash;
       }
       private int? _LongHash=null;
       public bool Equals(FasterComparingList<T> list)
       {
           if (InnerList.Count==list.Count) {
               return true;
           }
           // you could also cache the sorted state and skip this if a list hasn't
           // changed since the last sort
           // not sure if native `List` does
           list.Sort();
           InnerList.Sort();
           return InnerList.SequenceEqual(list);
       }
       protected int GetLongHash()
       {
           return .....
           // something to create a reasonably good hash code -- which depends on the 
           // data. Adding all the numbers is probably fine, even if it fails a couple 
           // percent of the time you're still orders of magnitude ahead of sequence
           // compare each time
       } 
    }
