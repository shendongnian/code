      private Int64 GetTime()
      {
          Int64 retval=0;
          var  st=  new DateTime(1970,1,1);
          TimeSpan t= (DateTime.Now.ToUniversalTime()-st);
           retval= (Int64)(t.TotalMilliseconds+0.5);
          return retval;
      }
     
