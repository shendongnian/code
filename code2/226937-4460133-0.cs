    namespace Working_with_Files
    {
    	public class Files
    	{
    		private static Files instance;
    		public static Files Instance { get { return instance; } }
    		
    		static Files()
    		{
    			instance = new Files();
    		}
    		
    		private Files()
    		{
    		}
    		
    		public bool CheckFile(string path)
    		......no change in rest of code.....
    	}
    }
