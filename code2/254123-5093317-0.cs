    public class Lamp
    {
        Bulb inThelamp = new Bulb();
        inTheLamp.Glowing += myLampMethod;
    
        // If these arguments have been defined for this event that is
        public void myLampMethod(object sender, EventArgs e) 
        {
            // Code to react to the light suddenly being on
        }
    }
