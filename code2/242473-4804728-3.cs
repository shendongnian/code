    //just to be sure correct value is captured everytime
    string copy = item;
    //Predicate is in System.Predicate<T>
    Predicate<string> predicate = itemtocheck => {   
           itemtocheck == copy;
       };
    UserRole = Array.Exists(Enum.GetNames(typeof(Role)), predicate);
