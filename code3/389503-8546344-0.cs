      class OnlyOneCallerAllowed
        {     
           private static readonly object locker = new object();        
            public static void OnlyOneMethodCanWrite()
            {
               lock (locker)
                {
        	     using(StreamWriter sw = File.AppendText("temp"))
        	     {
        	 	   sw.WriteLine("Check1=Success");
        	     }
        	    
        	 }
         }
