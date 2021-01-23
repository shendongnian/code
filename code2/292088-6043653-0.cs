    class a
    {
        b bee;
    	public a()
    	{
    	    bee = new b();
    	}
    	
        void m()
        {
            b.write(oXL,oWB); //will be called multiple times
        }
    }
    
    class b
    {
        public b()
        {
            Excel._Application oXL = new Excel.Application();
            Excel._Workbook oWB = (Excel._Workbook)(oXL.Workbooks.Add(Type.Missing));
        }
    
        write()
        {
            oXL.Visible = true;
        }
    }
