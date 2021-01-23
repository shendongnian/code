    public class SomeController
    {
	private Dictionary<string, Func<UserData,ActionResult>> handleAction = 
		new Dictionary<string, Func<UserData,ActionResult>>
		{ { "Back", SaveAction },
		  { "Next", NextAction },
		  { "Save", SaveAction } };
 
	public ActionResult TheAction(string whichButton, UserData userData)
	{
		if(handleAction.ContainsKey(whichButton))
		{
			return handleAction[whichButton](userData);
		}
 
		throw Exception("");
	}
 
	private ActionResult NextAction(UserData userData)
	{
		// do cool stuff
	}
    }
