    namespace CommandNameSpace
    {
        public class MainCalss
        {
            public BaseCommand<string> OrderCommand { get; private set; }
    	    private Dictionary<string, string> _selectedCommandType = new Dictionary<string, string>();
    	    private KeyValuePair<string, string> _selectedLanguage;    
    
            public ServicesControlViewModel()
            {
               OrderCommand = new BaseCommand<string>(cmdOrderCommand);
    
               LisCommandType.Add("DrinkCommand", "Drink");
    	       LisCommandType.Add("DrinkWithSugarCommand", "Drink With Sugar");
    	       LisCommandType.Add("DrinkWithMilkCommand", "Drink With Milk");
    	       LisCommandType.Add("DrinkWithSugarAndMilkCommand", "Drin kWith Sugar And Milk");    
               SelectedCommandType = new KeyValuePair<string, string>("DrinkCommand", "Drink");
    	}
    
    	public Dictionary<string, string> LisCommandType
    	{
    	    get
    	    {
    		return _liscommandType;
    	    }
    	    set
    	    {
    		_liscommandType = value;
    	    }
    	}
    
    	public KeyValuePair<string, string> SelectedCommandType
    	{
    	    get
    	    {
    		return _selectedCommandType;
    	    }
    	    set
    	    {
    		_selectedCommandType = value;
    	    }
    	}
    
           private void cmdANextNumeroCommand(string paramerter)
            {
               
                    switch (SelectedLanguage.Key)
                    {
                        case "DrinkCommand":
    
                            //Instruction for DrinkCommand
    
                            break;
                        case "DrinkWithSugarCommand":
    
                            //Instruction for DrinkWithSugarCommand
    
                            break;
                        case "DrinkWithMilkCommand":
    
                          //Instruction for DrinkWithMilkCommand
    
                            break;
                        case "DrinkWithSugarAndMilkCommand":
    
                            //Instruction for DrinkWithSugarAndMilkCommand
                            break;
                    }
            }
        }
    }
