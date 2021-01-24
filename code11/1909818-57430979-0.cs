    using (var stream = File.Open(filePath, FileMode.Create))
                {
                    var writer = new DataContractSerializer(myViewModelObject.GetType());
                    writer.WriteObject(stream, myViewModelObject);
                    stream.Close();
                }
