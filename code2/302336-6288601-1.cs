    public override void Commit(System.Collections.IDictionary savedState) 
    { 
       base.Commit(savedState); 
       System.Windows.Forms.MessageBox(savedState["bcvalue"].ToString());    
    }
