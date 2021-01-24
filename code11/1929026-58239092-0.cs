csharp
public string ValidateLogin(string auth)
{
	using (new NoDispose())
	{
		using (new NoDispose())
		{
			try
			{
				int dtRowsCount = 10;
				string authDesignation = "";
				if (dtRowsCount <= 0)
					return "WrongPasswordArea";
				switch (authDesignation)
				{
					case "Admin":
						return "AdminDashboard";
					case "Security":
						return "SecurityDashboard";
					case "SecurityDashboard":
						return "SecurityDashboard";
					case "Visitor":
					default:
						return "VisitorDashboard";
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
_Disclaimer. I do not claim that the logic implemented above does exactly what the previous did, nor that it conforms to your requirements._
# Using chains
And btw, you can chain `using` statements in the following manner.
csharp
using (var a = new NoDispose())
using (var b = new NoDispose())
{
    // both a and b are available in here
}
