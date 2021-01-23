     EventHandler checkSomething = delegate(object sender, EventArgs e) {
         
        
               if (somethingHappened) {
                    //STOP
                    return;
                }//end if
            
                UIButton theButton = (UIButton)sender;
                if (theButton.Title == "Button1") {
                //do something for Object1
                }//end if
            
                if (theButton.Title == "Button2") {
                //do something for Object 2
                }
    };
