    var clickCount = 0;
    var timeoutID  = 0;
    function OnClick()
    {
        clickCount++;
        if (clickCount >= 2) {
           clickCount = 0;          //reset clickCount
           clearTimeout(timeoutID); //stop the single click callback from being called
           DoubleClickFunction();   //perform your double click action
        }
        else if (clickCount == 1) {
           //create a callback that will be ran in a few miliseconds
           //to allow the user time to click again if they are double clicking
           
           var callBack = function(){ 
                             //make sure this wasn't fired at
                             //the same time they double clicked
                             if (clickCount == 1) {      
                                clickCount = 0;         //reset the clickCount
                                SingleClickFunction();  //perform your single click action
                             }
                          };
           //This will call the callBack function in 1/2 a second.
           //If by that time they haven't clicked the LinkButton again
           //We will perform the single click action. You can adjust the
           //Time here to control how quickly the user has to double click.
           timeoutID = setTimeout(callBack, 500); 
        }
    }
