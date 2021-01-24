    string delimiter = Environment.NewLine + "##"; 
    
    int sum = 0;
    
    var parts = text
      .Split(delimiter, StringSplitOptions.None)
      .Select(item => {
         int index = sum;
         sum = delimiter.Length + item.Length;
    
         return new {
           item,  // item
           index  // its index
         };  
       });
