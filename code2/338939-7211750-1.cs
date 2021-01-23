      public void Assign(ref MyObject obj)
      {         
         if (some condition)
         {
            string tmp = null;
            //can't pass in MyObject.MyString to out param, so we need to use tmp
            m_cache.TryGetValue("SomeKey", out tmp); //assumption: key is guaranteed to exist if condition is met
            obj.MyString = tmp;
         }    
         else
         {
             obj.MyString = MagicFinder(); //returns the string we are after
         }
      }
