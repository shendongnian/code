    void fooButton_Click(object sender, EventArgs args) {
       try {
            fooBusinessClass.foo();
       } catch(FooException fe) {
            //if(MessageBox.Show(fe.Message)==DialogResult.OK) fooBusinessClass.continuefoo(); //if you have several options
            MessageBox.Show(fe.Message);
       }
    }
