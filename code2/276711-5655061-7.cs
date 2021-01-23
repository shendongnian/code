    void Main()
    {
    	var lists = new string[] { "123", "456", "789" };
    	
    	foreach (var seq in RotateGrid(lists))
    		Console.WriteLine(string.Join(", ", seq));
    }
    
    public IEnumerable<IEnumerable<T>> RotateGrid<T>(IEnumerable<IEnumerable<T>> grid) 
    {
    	int rows = grid.Count();
    	int cols = grid.First().Count();
    	return 
    		from i in Enumerable.Range(0, rows + cols - 1)
    		select (
    			from j in Enumerable.Range(0, i + 1)
    			where i - j < rows && j < cols
    			select grid.ElementAt(i - j).ElementAt(j)
    		);
    }
