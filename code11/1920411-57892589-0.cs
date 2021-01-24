    public class TheNewCollectionToUse<T> : ACollection<T>, ICollection<T>
            {
                public TheNewCollectionToUse()
                {
    #if ORMS_OLD
                    TheList = new List<T>();
    #else
                    TheList = new ACollection<T>();
    #endif
                }
    
    #if ORMS_OLD
                public TheNewCollectionToUse(List<T> theList)
                {
                    TheList = theList;
                }
    
                public ICollection<T> TheList { get; set; }
    
                public int Count => TheList.Count();
                public bool IsReadOnly => TheList.IsReadOnly;
    
                public void Add(T item)
                {
                    TheList.Add(item);
                }
    
                public void Clear()
                {
                    TheList.Clear();
                }
    
                public bool Contains(T item)
                {
                    return TheList.Contains(item);
                }
    
                public void CopyTo(T[] array, int arrayIndex)
                {
                    TheList.CopyTo(array, arrayIndex);
                }
    
                public IEnumerator<T> GetEnumerator()
                {
                    return TheList.GetEnumerator();
                }
    
                public bool Remove(T item)
                {
                    return TheList.Remove(item);
                }
    
                IEnumerator IEnumerable.GetEnumerator()
                {
                    return TheList.GetEnumerator();
                }
    
    #else
                public TheNewCollectionToUse(ACollection<T> theList)
                {
                    TheList = theList;
                }
    
                public ACollection<T> TheList { get; set; }
    
                public int Count; // put suitable code for ACollection
    
                public bool IsReadOnly; // put suitable code for ACollection
    
                public void Add(T item)
                {
                    // put suitable code for ACollection
                }
    
                public void Clear()
                {
                    // put suitable code for ACollection
                }
    
                public bool Contains(T item)
                {
                    // put suitable code for ACollection
                }
    
                public void CopyTo(T[] array, int arrayIndex)
                {
                    // put suitable code for ACollection
                }
    
                public IEnumerator<T> GetEnumerator()
                {
                    // put suitable code for ACollection
                }
    
                public bool Remove(T item)
                {
                    // put suitable code for ACollection
                }
    
                IEnumerator IEnumerable.GetEnumerator()
                {
                    // put suitable code for ACollection
                }
                // --------------------------------------------------------------
                // add more methods if needed to override ACollection methods
                // --------------------------------------------------------------
    #endif      
            }
