        private bool _isIt;
        
        public List<object> mylist;
        
        public bool isIt{
          get{return _isIt;}
          set{
             _isIt = value;
             myList[2] = value;
           }
         }
