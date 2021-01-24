csharp
        try
        {
            //this crashes 
            throw new Exception("test");
        }
        catch (System.AggregateException e)
        {
           // handle in case of aggregate exception
        }
        catch (Exception ex)
        {
           // in case of other exceptions
        }
