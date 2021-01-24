    public class CarEx
        {
            string Manfacturer { get; set; }
            string RegistrationNr { get; set; }
            float Fuel;
            float Speed;
            bool IsRunning;
    
            public CarEx(string manuf, float fuel, string regNr)
            {
                Manfacturer = manuf;
                this.Fuel = fuel;
                RegistrationNr = regNr;
                Console.WriteLine("_____________________________________________________");
                Console.WriteLine($"Manufacturer; {manuf}, Fuel amount: {fuel}l, License: {regNr}");
                Console.WriteLine("______________________________________________________");
            }
    
            public void ChooseEngineType()
            {
                Engine v4 = new Engine("v4", 200, 0.7f);
    
            }
    
    public void Accelerate()
            {
    Speed += 6.0f;
                    
    //Fuel rate set for v4 object
    Fuel -= Engine.FuelConsumtionRate;
    }
