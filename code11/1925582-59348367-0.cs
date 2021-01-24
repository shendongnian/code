    var multipartFormDataContent = new MultipartFormDataContent();
    var fileContent = new ByteArrayContent(File.ReadAllBytes(fileToUpload));
    multipartFormDataContent.Add(fileContent, "file", fileName);
    multipartFormDataContent.Add(new StringContent("Author"), "Author");
    multipartFormDataContent.Add(new StringContent("13"), "AuthorId");
    // parameter name should follow this template
    // {collection_name}[{index}].{property}
    multipartFormDataContent.Add(new StringContent("key1"), "Metadata[0].Key");
    multipartFormDataContent.Add(new StringContent("value1"), "Metadata[0].Value");
