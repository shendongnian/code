    try
    {
       // take a object as argument and try parse it to an int here 
       // or a TryParse will return a true/false if bool can return without exception.
       int something = int.Parse(j);
    }
    catch (TestOnJThatcanThrowOutOfMemoryException e)
    {
       return true;
    }
    catch (OutOfMemoryException e)
    {
        // this will be hit if it isn't a TestOnJ.. exception
        return false;
    }
    catch 
    {
        // and here if not any of above
        return false;
    }
