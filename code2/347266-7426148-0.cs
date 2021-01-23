    public partial class App : Application
    {
        public static int BusStopNumber { get; set;}
    }
    //And in your application you can access it like so:
    App.BusStopNumber = 10;
