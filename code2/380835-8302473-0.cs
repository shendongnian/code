    [DataContract]
    public class NRResult
    {
        [DataMember(Name = "times")]
        public IEnumerable<string[]> Timings { get; set; }
    }
    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(NRResult));
    using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(result1)))
    {
        var item = (NRResult)serializer.ReadObject(stream);
        foreach (var route in item.Timings)
        {
            var _item = new{
                    Route = route[0],
                    Time = route[1],
                    Destination = route[2],
                    AimedDepart = route[3],
                    ExpectedDepart = route[4],
                    OpRef = route[5]
                };
            Console.WriteLine(_item);
        }
    };
