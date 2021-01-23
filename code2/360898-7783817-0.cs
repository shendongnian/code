     private void userEnteredText()
     {
           this.backupModel = model;     
           Model clonedModel = (Model)model.Clone();
           this.myButton.Size = new System.Drawing.Size(10,5);
           MessageBox.Show("buttons made small");
           model = this.backupModel;     
           MessageBox.Show("clone complete and buttons restored to orig size");
     }
