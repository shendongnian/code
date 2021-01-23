     EventHandler checkSomething = delegate(object sender, EventArgs e) {
         
        
               if (somethingHappened) {
                    //STOP
                    return;
                }//end if
            
                if (sender is Object1) {
                //do something for Object1
                }//end if
            
                if (sender is Object2) {
                //do somerhing for Object 2
                }
    };
