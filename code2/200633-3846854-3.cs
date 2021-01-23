        //In my project, I plan to have such an abstract class, and since it is a game _creator_, the app will generate a C# file that contains derived types containing info that users will specify using a GUI Editor.
    abstract class Room
    {
        protected Dictionary<string, GameObject> objects;
    	
        public GameObject GetObject(string objName) {...//get relevant object from dictionary}
    }
    
    
    class FrontYard : Room
    {
    	
    	public FrontYard()
    	{
    		GameObject bottle;
    		bottle.Name = "Bottle";
    		bottle.Scripts["FillWithWater"] = Room1_Fill_Bottle_With_Water;
    		bottle.Scripts["ThrowAtWindow"] = Room1_Throw_Bottle_At_Window;
    		//etc...
    	}
    
        void void Room1_Fill_Bottle_With_Water()
        {
             API.Print("You fill the bottle with water from the pond");
             API.SetVar("bottleFull", "true");         
        }
    
        void Room1_Throw_Bottle_At_Window()
        {
             API.Print("With all your might, you hurl the bottle at the house's window");
             API.RemoveFromInventory("bottle");
             API.UnlockExit("north");
             API.SetVar("windowBroken", "true");    
             //etc...     
        }    
    }
