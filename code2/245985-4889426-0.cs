    public class Document<T> where T: IEnumerable, IEnumerator
    {
        private Section<T>[] Sections{get;set;}
    }
    
    private class Section<T>
    {
         
         private Body<T> body {get;set;}
    }
    
    private class Body<T>
    {      
       private Items<T> Items {get;set;}
    }
    
    private class Items<T>:IEnumerable, IEnumerator
    {
        // Do all the plumbing for creating an enumerable collection
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        } 
        /* Needed since Implementing IEnumerator*/
        public bool MoveNext()
        {            
            return false;
        } 
        public void Reset()
        {
    
        } 
        public object Current
        {
            get{ return new object();}
        } 
    }
