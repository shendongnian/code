    XmlNamespaceManager manager = new XmlNamespaceManager (WebConfigDoc.NameTable);
            manager.AddNamespace("bindings", "urn:schemas-microsoft-com:asm.v1");
            XmlNode root = WebConfigDoc.DocumentElement;
 
    
    XPathNavigator assemblyBinding = root.CreateNavigator().
                                                     SelectSingleNode("//bindings:assemblyBinding", manager);
    
                   assemblyBinding.AppendChild(MyNewNode());
    
    private string MyNewNode()
    {
    
       string Node = "<dependentAssembly>" +
                                          "<assemblyIdentity name=\"newone\" "+
                                          " publicKeyToken=\"608967\" />" +
                                          "<bindingRedirect oldVersion=\"1\" newwVersion=\"2\" />" +
                                        "</dependentAssembly>";
                return Node ;  
    }
