    using System;
    namespace ClassLibrary2
    {
    
    public partial class ForbiddenException:MyException
    {
    	public ForbiddenException() {}
    	public ForbiddenException(string message):base(message)
    	{}
    	public ForbiddenException(string message, Exception inner):base(message,inner)
    	{}
    }
    
    }
