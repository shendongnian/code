    //Un-Hook when loading your default/existing data.
     private void SetDefaultData()
     {
         this.txtNameDepart.TextChanged -= new System.EventHandler(this.SomethingChanged); 
         this.txtNameDepart = "My default text";
         this.txtNameDepart.TextChanged += new System.EventHandler(this.SomethingChanged); 
     }
