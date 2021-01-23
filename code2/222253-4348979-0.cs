       public static void ThrowFaultException(this Exception exc)
        {
            //  Gives me the correct type...
            Type exceptionType = exc.GetType();
            var  genericType = typeof(FaultException<>).MakeGenericType(exceptionType);
            //  But how the heck do I use it?
            throw (Exception)Activator.CreateInstance(genericType, exc);
        }
