    int loop1, loop2;
    // Load NameValueCollection object.
    NameValueCollection coll = Request.QueryString; 
    // Get names of all keys into a string array. String[] arr1 = coll.AllKeys; 
    string parameters = "";
    for (loop1 = 0; loop1 < arr1.Length; loop1++) 
    {
      parameters += Server.HtmlEncode(arr1[loop1]) + "=" + coll.GetValues(arr1[loop1]);
      for (loop2 = 0; loop2 < arr2.Length; loop2++) 
      {
        parameters += Server.HtmlEncode(arr2[loop2]);
      } 
    }
