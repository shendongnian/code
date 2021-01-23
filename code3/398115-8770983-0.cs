    // Reference the library
    using System.Linq.Dynamic;
    // Now you can use a string as the argument for the Where method
    // You can compose this string dynamically
    string myProperty = "Title";
    var x = myList.Where(myProperty + " = " + myValue);
  
