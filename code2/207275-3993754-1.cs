    public static class Met
    {
    	static StockBox[] stockBox = null;
        public static StockBox[] CreateMap(string[] stock, TableLayoutPanel boxContainer)
        {
            stockBox = new StockBox[Var.stockCount + 1];
    
            for (int i = 1; i <= Var.stockCount; i++)
            {
                stockBox[i] = new StockBox();
                stockBox[i].StockText = stock[i];
                boxContainer.Controls.Add(stockBox[i]);
            }
    
            return stockBox;
        }
    	
    	public static AccessStockBox()
    	{
    		if (stockBox != null)
    		{
    			//you should be able to access stockbox here
    		}
    	}
    }
