    string postData = Console.ReadLine();
    
    using (System.Net.WebCient wc = new System.Net.WebClient())
    {
        wc.Headers.Add("Content-Type","application/x-www-form-urlencoded");
        // Upload the input string using the HTTP 1.0 POST method.
        byte[] byteArray = System.Text.Encoding.ASCII.GetBytes(postData);
        byte[] byteResult= wc.UploadData("http://targetwebiste","POST",byteArray);
        // Decode and display the result.
        Console.WriteLine("\nResult received was {0}",
                          Encoding.ASCII.GetString(byteResult));
    }
