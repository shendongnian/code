    public class B: A
    {
            public void RunA()
            {
                try
                {
                    // statement: exception may occur here
                }
                catch(Exception ex)
                {
                    // Do whatever you want to do here if you have to do specific stuff
                    // when an exception occurs here
                    ...
                    
                    // Then rethrow it with additional info : it will be processed by the Base class
                    throw new ApplicationException("My info", ex);
                }
        }
    }
