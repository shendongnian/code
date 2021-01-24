     var fileContent = System.IO.File.ReadAllText(jsonFilename);
                        if (!string.IsNullOrWhiteSpace(fileContent) && Utility.IsValidJson(fileContent))
                        {
                            var obj = JsonSerializer.Deserialize<object>(fileContent);
                            Result = new OkObjectResult(obj);
                        }
                        else
                        {
                            Result = new NoContentResult();
                        }
