    try
    {
        if user name is exit
        {
            throw new UserNameExistsException("The Username Already Exist");
        }
    
        if e-mail is already exit
        {
            throw new EmailExistsException("The E-Mail Already Exist");
        }
    }
    catch(UserNameExistsException ex)
    {
        //Username specific handling
    }
    catch(EmailExistsException ex)
    {
        //EMail specific handling
    }
    catch(Exception ex)
    {
        //All other exceptions come here!
        Console.WriteLine("The Error is{0}", ex.Message);
    }
