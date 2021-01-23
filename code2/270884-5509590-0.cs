    try
    {
        SomeMethod();
    }
    catch (SpecificExceptionType1)
    {
        //do something based on what this exception means
    }
    catch (SpecificExceptionType2)
    {
        //ditto here
    }
    catch
    {
        //handle unexpected exceptions here
    }
