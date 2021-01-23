    LinkButton myDynamicLinkButton = new myDynamicLinkButton ();
    myDynamicLinkButton.ID = "lnkButton";
    
    myPlaceHolder.Controls.Add (myDynamicLinkButton);
    
    //........
    
    LinkButton otherReferenceToMyLinkButton = myPlaceHolder.FindControl ("lnkButton");
