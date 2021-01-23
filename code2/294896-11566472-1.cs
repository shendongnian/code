    using (Stream input = Assembly.GetExecutingAssembly().GetManifestResourceStream("AppLicensing.Resources.SAppStarter.exe"))
                            using (Stream output = File.Create(outputFilePath))
                            {
                                long sz = input.Length;
                                AddResource.CopyStream(input, output, sz);
                            }
                            //inject crypted bytes
                            AddResource.InjectResource(outputFilePath, Encryptor.cryptedbytes, "RT_RCDATA");
