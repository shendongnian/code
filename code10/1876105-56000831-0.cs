    namespace P.A_DBDataSetTableAdapters
    {
    	public partial class VD_TableAdapter
    	{
    		public int CommandTimeout
    		{
    			set
    			{
    				int i = 0;
    				while ((i < this.CommandCollection.Length))
    				{
    					if ((this.CommandCollection[i] != null))
    						this.CommandCollection[i].CommandTimeout = value;
    					i = (i + 1);
    				}
    			}
    		}
    	}
    }
