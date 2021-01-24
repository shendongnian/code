    void Main()
    {
	    var funds = new List<Fund>();	
	    funds.Add(new Fund() { Age = 18, Money = 100000 });
	    funds.Add(new Fund() { Age = 20, Money = 101000 });
	    //Here is normally your code with loading it from CSV
	    //File.ReadAllLines(filepath)
	    //		  .Skip(1)
	    //		  .Select(v => Fund.FromCsv(v))
	
	    var value = funds.OrderBy(t => t.SortingFactor);
    }
    public class Fund
    {
	    public int Age { get; set; }
	    public decimal Money { get; set; }
	    public decimal SortingFactor
	    {
		    get
		    {
			    //Here is your domain algorithm you must sort out first (your example data would be)
			    return Money / Age;
		    }
	    }
    }
