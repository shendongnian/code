    public class RadioPlayer
        {
            List<RadioStation> stations = new List<RadioStation>();
            public void DoSomething()
            {
                stations.Add(new RadioStation() { Frequency = 100, StationName = "Radio2", Genre = Genre.Music });
            }
        }
    
