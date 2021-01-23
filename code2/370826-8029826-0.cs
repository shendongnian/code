    public class ThingType : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public string ThingName { get; set; }
        private bool thingAvailable;
        public bool ThingAvailable { get { return thingAvailable; } set { thingAvailable = value; PropertyChanged(this, new PropertyChangedEventArgs("ThingAvailable")); } }
    }
    public class MainVM 
    {
        public ObservableCollection<ThingType> MyThings { get; set; }
        
        public MainVM()
        {
            MyThings = new ObservableCollection<ThingType>();
            MyThings.Add(new ThingType() { ThingName = "thing 1" });
            MyThings.Add(new ThingType() { ThingName = "thing 2" });
        }
        public ThingType GetRandomThing()
        {
            var availableThings = MyThings.Where(x => x.ThingAvailable == true).ToArray();
            int randomThingIndex = new Random().Next(availableThings.Length - 1);
            availableThings[randomThingIndex].ThingAvailable = false;
            return availableThings[randomThingIndex];
        }
    }
