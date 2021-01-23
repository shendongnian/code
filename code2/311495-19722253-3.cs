                RenameManager.FilePath = @"C:\Users\therath\testApp\Model1.edmx";
                // Path of edmx file in the your solution
                RenameManager.Document.Load(@RenameManager.FilePath);
                RenameManager.nsmgr = new XmlNamespaceManager(RenameManager.Document.NameTable);
                RenameManager.nsmgr.AddNamespace("edmx", "http://schemas.microsoft.com/ado/2008/10/edmx");
                RenameManager.nsmgr.AddNamespace("edm", "http://schemas.microsoft.com/ado/2008/09/edm");
                //nsmgr.AddNamespace("ssdl", "http://schemas.microsoft.com/ado/2009/02/edm/ssdl");
                RenameManager.nsmgr.AddNamespace("cs", "http://schemas.microsoft.com/ado/2008/09/mapping/cs");
    
                try
                {
                    RenameManager.UpdateConceptualModelsSection();
                    RenameManager.UpdateMappingsSection();
                    RenameManager.Document.Save(@RenameManager.FilePath);
                }
    
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
