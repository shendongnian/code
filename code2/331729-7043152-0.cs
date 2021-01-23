    public class DicomDictionary<TElement> 
    {
            Dictionary<int, TElement> myElements = new Dictionary<int, TElement>();
            public TElement this[int DataElementTag]   
            {     
                  get     
                  {       
                     return myElements[int];     
                  }   
            } 
    }
