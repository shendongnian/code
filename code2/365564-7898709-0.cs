    void Main()
    {
    	DB.Categories = Categories;
    	
    	MyAwesomeClass awesomeness = new MyAwesomeClass();
    	awesomeness.DumpNumOfCategories();
    }
    
    class MyAwesomeClass {
    	
    	public MyAwesomeClass(){
    	
    	}
    	
    	public void DumpNumOfCategories(){
    		DB.Categories.Count().Dump();
    	}
    	
    }
    
    class DB{
    	public static ISessionTable<Category> Categories { get; set; }
    }
