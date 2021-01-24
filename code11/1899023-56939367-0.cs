        public int Index;
        private int currentIndex;
        
        void Update()
        {
           // Check if was updated
           if(Index != currentIndex)
           {
              currentIndex = Index ;
              switch(Index)
             { 
                case 1:
                currestList = DefendInventory ;
                 break;
             ...
             }
           }
        }
