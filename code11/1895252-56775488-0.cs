	public enum ControlActions
	{
		New,
		Edit,
		Delete
	}
	
	public static class ControlActionsExtender
	{
		public static bool IsActionAllowed(this ControlActions controlAction, Type controlType)
		{
			switch (controlAction)
			{
				case ControlActions.New:
					return controlType == typeof(UserControlA) || controlType == typeof(UserControlB) || controlType == typeof(UserControlC);
				case ControlActions.Edit:
					return controlType == typeof(UserControlA);
				case ControlActions.Delete:
					return controlType == typeof(UserControlA) || controlType == typeof(UserControlC);
			}
			return false;
		}
	}
