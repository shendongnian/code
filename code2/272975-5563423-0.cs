    try
    {
       ...
    }
    catch(Exception ex)
    {
       if(ex is CommunicationException || ex is SystemException)
       {
          ...
       }
       else
       {
         ... // throw; if you don't want to handle it
       }
    }
