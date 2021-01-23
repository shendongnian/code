    class productGridViewModel{ 
      Public String ProductName{get;set} 
      Public String ProductImage{get;set} 
      Public String ProductDescription{get;set} 
      Public String CategoryName{get;set} 
    
    public string ProductDisplayName
            {
                get
                {
    //Please dont mind this code.. I am sure you can write it in much better way.
                    return typeof(Producy).GetProperty("Name").GetCustomAttributes(typeof(DisplayName))[0].ToString();
                }
            }
    } 
