    public delegate void NameIndicator( string name );
    class Program
    {
        static void Main( string[] args )
        {
            //Create the instance of the class
            Car car = new Car( "Audi" );
            //Register the event with the corresponding method using the delegate
            car.Name += new NameIndicator( Name );
            //Call the start to invoke the Name method below at runtime.
            car.Start();
            Console.Read();
        }
        /// <summary>
        /// The method that can subscribe the event of the defined class.
        /// </summary>
        /// <param name="name">Name assigned from the caller.</param>
        private static void Name( string name )
        {
            Console.WriteLine( name );
        }
    }
    public class Car
    {
        //Event for the car class.
        public event NameIndicator Name;
        string name;
        public Car( string nameParam )
        {
            name = nameParam;
        }
        //Invoke the event when the start method is called.
        public virtual void Start()
        {
            Name( name );
        }
    }
