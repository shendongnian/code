    void Main()
    {
    			var machine = new SFM.Machine(new StatePaused());
    			var output = machine.Command("Input_Start", Command.Start);
    			Console.WriteLine(Command.Start.ToString() + "->  State: " + machine.Current);
    			Console.WriteLine(output);
    
    			output = machine.Command("Input_Pause", Command.Pause);
    			Console.WriteLine(Command.Pause.ToString() + "->  State: " + machine.Current);
    			Console.WriteLine(output);
    			Console.WriteLine("-------------------------------------------------");
    }
    	public enum Command
    	{
    		Start,
    		Pause,
    	}
    	
    	public class StateActive : SFM.State
    	{
    
    		public override void Handle(SFM.IContext context)
    
    		{
    			//Gestione parametri
    			var input = (String)context.Input;
    			context.Output = input;
    
    			//Gestione Navigazione
    			if ((Command)context.Command == Command.Pause) context.Next = new StatePaused();
    			if ((Command)context.Command == Command.Start) context.Next = this;
    
    		}
    	}
    	
    	
    public class StatePaused : SFM.State
    {
    
         public override void Handle(SFM.IContext context)
    
         {
    		 
    		 //Gestione parametri
    		 var input = (String)context.Input;
    		 context.Output = input;
    
    		 //Gestione Navigazione
    		 if ((Command)context.Command == Command.Start) context.Next = new	StateActive();
    		 if ((Command)context.Command == Command.Pause) context.Next = this;
    
    
         }
    
     }
