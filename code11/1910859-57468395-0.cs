     public class Stations : IStations
        {
            Lazy<List<StationModel>> _lazyStation = new Lazy<List<StationModel>>(() => Provider.GetStationsFromProvider().Result, isThreadSafe: true);
            public List<StationModel> LstStationModel
            {
                get { return _lazyStation.Value; }
                set { _lazyStation = new Lazy<List<StationModel>>(() => value, isThreadSafe: true);  }
            }
             
        }
