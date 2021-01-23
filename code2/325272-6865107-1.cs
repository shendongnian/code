    bool isLoggedIn = false;
    try
    {
        isLoggedIn = connectToServer(Path, username, password);
    }
    catch (ExceptionType1 ex1)
    {
        //Recover from this exception type.
    }
    catch (ExceptionType2 ex2)
    {
        //Recover from this exception type.
    }
