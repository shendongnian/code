    Form ObjRefToFirstForm;
    public YourSecondForm( Form passedInVar )
    {
       // preserve the first form
       ObjRefToFirstForm = passedInVar;
    }
    // Now, however you want to handle... via a button click, the text change event, etc
    public void SendDataToForm1()
    {
       // via calling the METHOD on form 1 that is public
       ObjRefToFirstForm.SetMyObj( this.SomeOtherTextbox.Text );
       // via a SETTER on form 1
       ObjRefToFirstForm.ViaSetAsProperty = this.SomeOtherTextbox.Text;
    
       // sample to GET something from form 1 via method
       string TestGet = ObjRefToFirstForm.GetMyObjectText();
       // or from the exposed property
       TestGet = ObjRefToFirstForm.GettingText;
        
       // Now, try via the one property that has both a setter and getter
       ObjRefToFirstForm.TextContent = this.SomeOtherTextbox.Text;
       TestGet = ObjRefToFirstForm.TextContent;
    }
