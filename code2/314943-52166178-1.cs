    ***
    
    > HttpResponse.Buffer Property
    
    ***
    Gets or sets a value indicating whether to buffer output and send it after the complete response is finished processing.
    true if the output to client is buffered; otherwise, false.
    
    ***
    
    > HttpResponse.Clear Method
    
    ***
    
    Clears all content output from the buffer stream
    
    The following example sets the ContentType property for the response to image/jpeg, calls the Clear method to remove other content that might be attached to the response, and then sets the BufferOutput property to true so that the complete page will be processed before any content is sent to the requesting client.
    
    // Set the page's content type to JPEG files
    // and clears all content output from the buffer stream.
    Response.ContentType = "image/jpeg";
    Response.Clear();
    
    // Buffer response so that page is sent
    // after processing is complete.
    Response.BufferOutput = true;
    
    
    ***
    
    > HttpResponse.ClearHeaders Method
    
    ***
    
    Clears all headers from the buffer stream.
    
    The following example calls the ClearHeaders method to ensure that no headers are sent with the current response. This technique can be especially important if the ASP.NET response is generating an image, such as a JPEG file. In this example the ContentType property is set to image/jpeg.
    
    
    // Clear headers to ensure none
    // are sent to the requesting browser
    // and set the content type.
    Response.ClearHeaders();
    Response.ContentType = "image/jpeg";
    -------------------------------------------------------------------------
    summary :
    asp.net keeps the header in a collection (Response.Headers) and the content in an output stream (Response.Output).
    
      Response.ClearHeaders - clears the current header collection
      Response.Clear - resets the output stream
      Response.ClearContent call Clear and is just a better name
    
    all three will fail if Response.Buffer == false, and any output was been written. 
