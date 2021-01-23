        string postData = "name=t&description=tt";
        byte[] byteArray = Encoding.UTF8.GetBytes(postData);
        // Set the ContentType property of the WebRequest.
        request.ContentType = "application/x-www-form-urlencoded";
        // Set the ContentLength property of the WebRequest.
        request.ContentLength = byteArray.Length;
        // Get the request stream.
        var stream = request.GetRequestStream();
        stream.Write( byteArray, 0, byteArray.Length );
