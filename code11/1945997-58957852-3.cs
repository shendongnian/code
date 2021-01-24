        try
        {
        }
        catch (XMSException e)
        {
          if(e.LinkedException!=null)
          {
            IBM.WMQ.MQException inner = (IBM.WMQ.MQException)e.LinkedException;
                Console.WriteLine("Reason:"+ inner.ReasonCode);
          }
          else
            Console.WriteLine(e);
        }
