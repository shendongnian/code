 public partial class UserDetails
    {
        public int? Level { get; set; }
        public string Unit { get; set; }
        public string Bio { get; set; }
        public bool? Gender { get; set; }
        public int? Mobile { get; set; }
        public string Photo { get; set; }
		 // Define the indexer to allow client code to use [] notation.
	   public object this[string propertyName]
	   {
	      get { 
		  	PropertyInfo prop = this.GetType().GetProperty(propertyName);
		  	return prop.GetValue(this); 
		  }
	      set { 
		  	PropertyInfo prop = this.GetType().GetProperty(propertyName);
		  	prop.SetValue(this, value); 
		  }
	   }
    }
Other than that, if you don't know the properties at runtime, you can use the [dynamic][2] type.
  [1]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/indexers/
  [2]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/using-type-dynamic
