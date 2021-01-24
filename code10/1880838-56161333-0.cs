    FileDetails fileDetails;
                    using (var reader = new StreamReader(file.OpenReadStream()))
                    {
                       var fileContent = reader.ReadToEnd();
                       var parsedContentDisposition = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                       fileDetails = new FileDetails
                          {
                              Filename = parsedContentDisposition.FileName,
                              Content = fileContent,
                              ContentType=file.ContentType
                           };
                     }
