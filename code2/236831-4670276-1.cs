        using System;
        using ADOX;
        
        namespace ConsoleApplication1
        {
        	class Class1
        	{
        		[STAThread]
        		static void Main(string[] args)
        		{
        			ADOX.Catalog cat = new ADOX.Catalog();
        
        			cat.Create("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\myFolder\myAccess2007file.accdb;");
        
        			Console.WriteLine("Database Created Successfully");
        
        			cat = null;
        
        		}
        	}
        }
