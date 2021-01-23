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
        
        			cat.Create("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\myFolder\myAccess2007file.accdb;Persist
    Security Info=False;");
        
        			Console.WriteLine("Database Created Successfully");
        
        			cat = null;
        
        		}
        	}
        }
