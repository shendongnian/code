       public string Name
       {
           get {
            if (null != FriendlyName)
                return FriendlyName;
            else
                return Name; //<-- StackOverflow
            }
            set
            {
                Name = value; //<-- StackOverflow
            }
        }
