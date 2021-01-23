    public class SomeHandler
    {
        public Request Get(int processid = 0) //specify a default value for the uri case /processed
        {
            if (processid == 0)
                return Context.Set<Request>().ToList(); //Context comes from my DbContext derived class which is part of my entity model.
            else
                return GetRequestFromProcessId(processid) //this is a private method in your handler class using Linq to SQL to retreive the data your interested in.  I can't see your handler so I'm making it up.
         }
     } 
