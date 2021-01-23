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
       private int? _LongHash;
       public bool Equals(FasterComparingList<T> list)
       {
           // both should be already sorted here from LongHash
           return InnerList.Count==list.Count &&
              InnerList.SequenceEqual(list);
       }
       protected int GetLongHash()
       {
           // this is ok, order doesn't seem to be important
           InnerList.Sort(); 
           return .....
           // something to create a reasonably good hash code -- which depends on the 
           // data. Adding all the numbers is probably fine, even if it fails a couple 
           // percent of the time you're still orders of magnitude ahead of sequence
           // compare each time
       } 
    }
