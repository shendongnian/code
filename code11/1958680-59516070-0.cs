    public class ColorFilter
    {
        ColorsOrderer colorsOrderer;
    
        public ColorFilter(ColorsOrderer colorsOrderer)
        {
            this.colorsOrderer = colorsOrderer;
        }
    
        public string OrderColors(string colors)
        {
            return string.Join("", colors.ToCharArray().OrderBy(i => colorsOrderer.Order[i]));
        }
    }
    
    
    public class Filterer1
    {
    	ColorFilter colorFilter;
    	
        public Filterer1(ColorFilter colorFilter)
        {
    		this.colorFilter = colorFilter;
        }
    	
    	public string OrderColors(string colors)
        {
            return this.colorFilter(colors);
        }
    }
    
    public class Filterer2
    {
    	ColorFilter colorFilter;
    	
        public Filterer2(ColorFilter colorFilter)
        {
    		this.colorFilter = colorFilter;
        }
    	
    	public string OrderColors(string colors)
        {
            return this.colorFilter(colors);
        }
    }
