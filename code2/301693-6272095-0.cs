    // IF you are going to use a struct
    public struct Structure1
    {
        readonly string String1;
        readonly string[] stringArr;
        readonly List<string> myList;
        public Structure1(string String1)
        {
            // all fields must be initialized or assigned in the 
            // constructor
            // readonly members can only be initialized or assigned
            // in the constructor
            this.String1 = String1
    
            // initialize stringArr - this will also make the array 
            // a fixed length array as it cannot be changed; however
            // the contents of each element can be changed
            stringArr = new string[] {};
            // if you use a List<string> instead of array, you can 
            // initialize myList and add items to it via a public setter
            myList = new List<string>();
        }
    
        public List<string> StructList
        {
            // you can alter the contents and size of the list
            get { return myList;}
        }
    }  
