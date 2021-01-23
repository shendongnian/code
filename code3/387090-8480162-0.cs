    private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
    {
                   dgr.EndEdit();
                   if(ds.GetChanges()!=null)
                   {
                       ds.WriteXml(path);
                   }
                }
    
    }
      
