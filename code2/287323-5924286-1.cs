    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace fsm
    {
	class Program
	{
		static void Main(string[] args)
		{
			var fsm = new FiniteStateMachine();
			Console.WriteLine(fsm.State);
			fsm.ProcessEvent(FiniteStateMachine.Events.PlugIn);
			Console.WriteLine(fsm.State);
			fsm.ProcessEvent(FiniteStateMachine.Events.TurnOn);
			Console.WriteLine(fsm.State);
			fsm.ProcessEvent(FiniteStateMachine.Events.TurnOff);
			Console.WriteLine(fsm.State);
			fsm.ProcessEvent(FiniteStateMachine.Events.TurnOn);
			Console.WriteLine(fsm.State);
			fsm.ProcessEvent(FiniteStateMachine.Events.RemovePower);
			Console.WriteLine(fsm.State);
			Console.ReadKey();
		}
		class FiniteStateMachine
		{
			public enum States { Start, Standby, On };
			public States State { get; set; }
			public enum Events { PlugIn, TurnOn, TurnOff, RemovePower };
			private Action[,] fsm;
			public FiniteStateMachine()
			{
				this.fsm = new Action[3, 4] { 
					//PlugIn,		TurnOn,					TurnOff,			RemovePower
					{this.PowerOn,	null,					null,				null},				//start
					{null,			this.StandbyWhenOff,	null,				this.PowerOff},		//standby
					{null,			null,					this.StandbyWhenOn,	this.PowerOff} };	//on
			}
			public void ProcessEvent(Events theEvent)
			{
				this.fsm[(int)this.State, (int)theEvent].Invoke();
			}
			private void PowerOn() { this.State = States.Standby; }
			private void PowerOff() { this.State = States.Start; }
			private void StandbyWhenOn() { this.State = States.Standby; }
			private void StandbyWhenOff() { this.State = States.On; }
		}
	}
    }
