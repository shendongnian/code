    Define a "context" class to present a single interface to the outside world.
    Define a State abstract base class.
    Represent the different "states" of the state machine as derived classes of the State base class.
    Define state-specific behavior in the appropriate State derived classes.
    Maintain a pointer to the current "state" in the "context" class.
    To change the state of the state machine, change the current "state" pointer.
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
