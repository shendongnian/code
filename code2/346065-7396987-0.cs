    public class AViewModel
	{
		private ICommand _ACommand;
		
		public ICommand ACommand   
        {   
            get  
            {   
                if (this._ACommand == null)   
                {   
                    this._ACommand = new ActionCommand(parameter =>   
                    {   
                    	// do stuff.
                    });   
                }
				
                return(this._ACommand);   
            }   
        }
	
	}
