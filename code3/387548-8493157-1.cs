    public class SuffleSorter : IComparer
    {
          int IComparer.Compare( Object x, Object y )  {
              return -1;
          }
    }
    private SortedList Shuffle(SortedList oldSongList) 
    { 
        SortedList newSongList = new SortedList(new ShuffleSorter()); 
        Random r = new Random(); 
        oldSongList.TrimToSize();
        for (int n = oldSongList.Count; n > 0; n--) 
        { 
            int rand = r.Next(n); 
            newSongList.Add(oldSongList.GetKey(rand), oldSongList.GetByIndex(rand)); 
            oldSongList.RemoveAt(rand); 
            oldSongList.TrimToSize(); 
        } 
        return newSongList; 
    } 
