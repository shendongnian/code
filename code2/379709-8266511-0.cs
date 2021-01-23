    using System;
    using ADOX;
    
    namespace ConsoleApplication1
    {
    	class Class1
    	{
    		[STAThread]
    		static void Main(string[] args)
    		{
    			ADOX.CatalogClass cat = new ADOX.CatalogClass();
    
    			cat.Create("Provider=Microsoft.Jet.OLEDB.4.0;" +
    				   "Data Source=D:\\AccessDB\\NewMDB.mdb;" +
    				   "Jet OLEDB:Engine Type=5");
    
    			Console.WriteLine("Database Created Successfully");
    
    			cat = null;
    
    		}
    	}
    }
