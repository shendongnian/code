    public class ProcessRequestThread
    {
      private Thread ProcessThread;
      private HttpListenerContext Context;
      public ProcessRequestThread()
      {
        ProcessThread = new Thread( ProcessRequest );
        ProcessThread.Start();
      }
      private void ProcessRequest(object contextObject)
      {
        Context = (HttpListenerContext)contextObject;
        // handle request
        if (someCondition())
        {
          EncapsulateMe(400, "Missing something");
        }
        else
        {
          EncapsulateMe(200, "Everything OK");
        }
      }
      private void EncapsulateMe(int code, string description)
      {
        Context.Response.StatusCode = code;
        Context.Response.StatusDescription = description;
      }
    }
