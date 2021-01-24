    foreach (var vehicle in vehicles)
        {
            Console.WriteLine(vehicle.Fuel().ToString());
            if(vehicle.GetType() is IRentable)
            {
                //Provide renting status
                Console.WriteLine((vehicle as IRentable)?.IsRented); //note I didn't cast for Truck directly
            }
            if(vehicle.GetType() is ITrackable)
            {
                //Provide position
                Console.WriteLine((vehicle as ITrackable)?.Position);
            }
        }
