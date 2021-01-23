     for(int i = 0; i < Request.Form.Count; i++)
     {
         string key = Request.Form.GetKey(i);
         string value = Request.Form[i];
         // now do something with the key-value pair...
     }
