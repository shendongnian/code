               var dataFilePath = Path.GetFileName(dataFileName);
               var dataFileUri = PackUriHelper.CreatePartUri(new Uri(dataFilePath, UriKind.Relative));
                // Create the Package
                using (var package = Package.Open(filePath, FileMode.Create))
                {
                    // Add the diagram view part to the Package
                    var pkgPart = package.CreatePart(dataFileUri, MediaTypeNames.Application.Octet);
                    var pkgStream = pkgPart.GetStream();
                    // Copy the data to the model view part
                    // diagramFileName Encoding.Default.GetBytes(text)
                    using (var modelStream = new FileStream(dataFileName, FileMode.Open, FileAccess.Read))
                    {
                        const int bufSize = 0x1000;
                        var buf = new byte[bufSize];
                        int bytesRead;
                        while ((bytesRead = modelStream.Read(buf, 0, bufSize)) > 0)
                        {
                            pkgStream.Write(buf, 0, bytesRead);
                        }
                    }
                    // Add a context Part to the Package
                    var pkgPartContext = package.CreatePart(ctxUri, MediaTypeNames.Application.Octet);
                    var ctxPkgStream = pkgPartContext.GetStream();
                    // Copy the data to the context part
                    using (var ctxStream = new FileStream(ctxFileName, FileMode.Open, FileAccess.Read))
                    {
                        const int bufSize = 0x1000;
                        var buf = new byte[bufSize];
                        int bytesRead;
                        while ((bytesRead = ctxStream.Read(buf, 0, bufSize)) > 0)
                        {
                            ctxPkgStream.Write(buf, 0, bytesRead);
                        }
                    }
                }
                // remove tmp files
                File.Delete(ctxFileName);
                File.Delete(dataFileName);
