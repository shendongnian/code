	public class ShellViewModel : Screen
	{
		public override void CanClose(Action<bool> callback)
		{
			//if(some logic...)
			callback(false); // will cancel close
		}
	}
