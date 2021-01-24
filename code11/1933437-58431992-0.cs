    class User{
        private string _id;
        public int Id
        {
           get
           {
               return _id;
           }
           set
           {
               if (Validate(value))
               {
                   _id = value;
               }
           }
        }
        User(){
        }
    }
