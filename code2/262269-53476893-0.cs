            private static void RestartClickOnceApplication()
            {
                try
                {
                    XDocument xDocument;
                    using (MemoryStream memoryStream = new MemoryStream(AppDomain.CurrentDomain.ActivationContext.DeploymentManifestBytes))
                    using (XmlTextReader xmlTextReader = new XmlTextReader(memoryStream))
                    {
                        xDocument = XDocument.Load(xmlTextReader);
                    }
                    var description = xDocument.Root.Elements().Where(p => p.Name.LocalName == "description").First();
                    var publisher = description.Attributes().Where(a => a.Name.LocalName == "publisher").First();
                    var product = description.Attributes().Where(a => a.Name.LocalName == "product").First();
    
                    var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.StartMenu) + @"\Programs\";
                    path += publisher.Value + @"\" + product.Value + ".appref-ms";
    
                    if (File.Exists(path))
                    {
                        Process.Start(path);
                        Application.Current.Shutdown();
                    }
                    else
                    {
                        Application.Current.Shutdown();
                    }
                }
                catch
                {
                    Application.Current.Shutdown();
                }
            }
