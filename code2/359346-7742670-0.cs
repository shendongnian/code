    public class IndexedClass
    {
        // Property 
        public byte this[int index]
        {
            get
            {
                return myList[index];
            }
            set
            {
                Modified = !myList[index].Equals(value);
                myList[index] = value;
            }
        }
    }
    public class IndexedClassGroup
    {
        // Property 
        public IndexedClass this[int index]
        {
            get
            {
                return myList[index];
            }
            set
            {
                Modified = !myList[index].Equals(value);
                myList[index] = value;
            }
        }
    }
