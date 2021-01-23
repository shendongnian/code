        class Program
    {
        static void Main(string[] args)
        {
            var postcode = "B";
            var stations = DestinationStation.GetDestinationStations();
            var query = from s in stations
                        where postcode.CompareTo(s.FromPostcode) > 0 && postcode.CompareTo(s.ToPostcode) < 0
                        select s;
            Console.WriteLine(query.ToList());
        }
    }
    public class DestinationStation
    {
        public string FromPostcode;
        public string ToPostcode;
        public static List<DestinationStation> GetDestinationStations()
        {
            return new List<DestinationStation> {   new DestinationStation {FromPostcode = "A", ToPostcode = "C"},
                                                    new DestinationStation {FromPostcode = "A", ToPostcode = "A"},
                                                    new DestinationStation {FromPostcode = "C", ToPostcode = "C"},
                                                    new DestinationStation {FromPostcode = "C", ToPostcode = "A"},
            };
        }
    }
