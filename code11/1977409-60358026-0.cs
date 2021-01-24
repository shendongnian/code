    public bool activated;
    public string type:
    //add extra variables
    
    Start() {
    //if my type is = 'skull' then change my activated state to 'truel'... else make it false
    //make extra variables false hasFire etc
    } 
    OnTriggeEnter2D() {
    Switch(type) {
    case  "fire" :
    //check if the thing we collided with has a object script and if the activated variable is true... Ifso then make own variable true and If the objwct touches thw skull everything works fine since thw skull variable has been set in the start method
    break;
    case  "totem" :
    //Same as fire... It just needs to be next to something activated... fire or skull
    break;
    case  "skullOnlyTotem" :
    //thia collision will check if the tag of the objevt we collided is the skull tag... If so the totem is activated, activated fire doesn't work with this tototem because we are not checking the activated parameter only for the skull tag
    break;
    case  "waterTotem" :
    //here we can have a condition that needs only a colission with a object that has a water tag and nothing more 
    break;
    case "obsidianTotem" :
    //here we can have a totem that needs fire and water to be activated since we need two conditions we will add to extra variables to the script, the hasFire bool and the hasWater bool. These will be set to false on start and here we will check their state... First if what we collided is in the activated state then we are next to a fire... if so.. Set hasfire =true then check if that thing we collided has tag =water... If so hasWater = true ; finally
    Compare if two conditions are true if so... Set the activated variable to true
    break;
    case "aLotOfConditions" :
    //for ten conditions you will need 10 new variables and set them all to false at start and in each collision check the tag belong to any of its clnditions if so turn variable true... At last check if all true if so... Activate... 
    break;
    } 
    } 
