    public class TelephoneNumber
    {
    	public string Number { get; set; }
    
    	public TelephoneNumber()
        {
    
        }
    
        public bool IsValid()
        {
    		//Add your code to check if number is valid, this is basic example
    		if (this.Number.Length > 5)
    			return true;
            else
    			return false;
        }
    }
