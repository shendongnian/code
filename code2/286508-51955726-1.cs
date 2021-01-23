    class Program
    {
        static void Main(string[] args)
        {
            //Set the features that you require for car. Consider it as checked in the UI.
            CarFeatures carFeatures = CarFeatures.AC | CarFeatures.Autopilot| CarFeatures.Sunroof;
            //Do the backend logic
            if (carFeatures.HasFlag(CarFeatures.Autopilot))
            {
                //Show Autopilot cars
            }
            //See the what carfeatures are required
            Console.WriteLine(carFeatures);
            //See the integer value of the carfeatures
            Console.WriteLine((int)carFeatures);
            Console.ReadLine();
        }
    }
    [Flags]
    public enum CarFeatures
    {
        AC=1,
        HeatedSeats= 2,
        Sunroof= 4,
        Autopilot= 8,
    }
