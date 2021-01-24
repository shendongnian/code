    public class FirstClass
    {
	     public string Run([CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "")
	    {
		    return $"CallerMemberName is {memberName}. Calling from {sourceFilePath}";
	    }
    }
    public class SecondClass
    {
        public string CallFirstClass()
        {
            var firstClass = new FirstClass();
            return firstClass.Run();
        }
    }
