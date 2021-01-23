	public abstract class MyController : Controller
	{
		protected IAttributeCommand[] commands;
		
		public MyController(IAttributeCommand[] commands) { this.commands = commands); }
		protected void DoActions(Type[] types)
		{
			foreach(var type in types)
			{
				var command = commands.FirstOrDefault(x=>x.Matches(type));
				if (command==null) continue;
				
				command.Execute();
			}
		}
	}
