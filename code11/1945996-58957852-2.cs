        try
        {
        }
        catch (XMSException e)
        {
          if(e.LinkedException!=null)
            Console.WriteLine(e.LinkedException.Message);
          else
            Console.WriteLine(e);
        }
