    using System;
    using System.IO;
    
    public class Table3rd : MemoryStream{
    };
    public class MyTable : IDisposable
    {
        public Table3rd Data { get; private set; }
    
    	public MyTable(){
    		Data = new Table3rd();
    	}
    	
        private bool disposed;
    
        public void Close()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
    		if (!disposed)
            {
    			try
    			{
    				if (disposing)
    				{
    					Data.Dispose();
    					disposed = true;
    				}
    			}
    			finally
    			{
    				Dispose(disposing);
    			}
    		}
        }
    
        public void Dispose()
        {
            Close();
        }
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		var table = new MyTable();
    		var data = table.Data;
    		var writer = new StreamWriter(data);
    		writer.Write("Table data");
    		writer.Flush();
    		data.Position = 0;
    		var reader = new StreamReader(data);
    		var mensaje = reader.ReadToEnd();
    		Console.WriteLine(mensaje);
    		// Too many dispose
    		table.Close();
    		table.Dispose();
    		table.Close();
    		table.Dispose();
    	}
    }
