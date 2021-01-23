    public class Form1 : Form
    {
        private string user_code;
    
      public string UserCode
        {
            get { return user_code; }
        }
    	
    	private string _testData;                //THIS IS NEEDED
    	public string TestData                   //THIS IS NEEDED
    	{
    		set { _testData = value;}        //THIS IS NEEDED
    	}
    
        public bool LoginUser()
        {
    		user_code = null;
    		if(textBox1.Text=="123" || TestData=="123")   //THIS IS NEEDED
    		{
    			user_code="usercode";
            }
        }
    }
