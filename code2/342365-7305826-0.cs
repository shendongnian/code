    static void ValidationCallback(object sender, ValidationEventArgs args)
    {
        // Not sure if the exception is guaranteed to not be null.
        if (args.Exception != null)
        {
            // Remember to always retain the InnerException (last argument is args.Exception).
            throw new MyException(args.Exception.LineNumber, args.Exception.LinePosition, args.Exception.Message, args.Exception);
        }
        // If the exception is null do what we can.
        throw new MyException(-1, -1, args.Message, args.Exception);
    }
