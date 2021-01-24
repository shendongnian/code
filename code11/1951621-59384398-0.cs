    MultipartFormDataContent multiContent = new MultipartFormDataContent();
    
    // appFileDTOs[] contains the data that I am going to submit (image and satellite data)
    // ------------------------ Object 1 -----------------------------------
    
    // Image 1
    HttpContent fileStreamContent1 = new StreamContent(image);
    fileStreamContent1.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data") 
    {
         Name = "appFileDTOs[0].File", 
         FileName = "YourFileName.something" // e.g. image1.jpg
    };
    fileStreamContent1.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
    multiContent.Add(fileStreamContent1);
    
    // Additional data for image 1
    multiContent.Add(new StringContent(appFileDTOs[0].CategoryName), "appFileDTOs[0].CategoryName");
    multiContent.Add(new StringContent(appFileDTOs[0].CategoryDescription), "appFileDTOs[0].CategoryDescription");
    multiContent.Add(new StringContent(appFileDTOs[0].Detail), "appFileDTOs[0].Detail");
    
    // ------------------------ Object 2 -----------------------------------
    
    // Image 2
    HttpContent fileStreamContent2 = new StreamContent(image);
    fileStreamContent2.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data") 
    {
         Name = "appFileDTOs[1].File", 
         FileName =  "YourFileName.something" // e.g. image2.jpg
    };
    fileStreamContent2.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
    multiContent.Add(fileStreamContent2);
    
    // Additional data for image 2
    multiContent.Add(new StringContent(appFileDTOs[1].CategoryName), "appFileDTOs[1].CategoryName");
    multiContent.Add(new StringContent(appFileDTOs[1].CategoryDescription), "appFileDTOs[1].CategoryDescription");
    multiContent.Add(new StringContent(appFileDTOs[1].Detail), "appFileDTOs[1].Detail");
    
    // Send (url = url of api)
    var response = await client.PostAsync(url, multiContent);
