    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    public class WGS84Coordinate {
        public string uuid{get; set;}
        public string name{ get; set;}
        public string suburb { get; set;}
        public string town { get; set;}
        public string district { get; set;}
        public string region { get; set;}
        public string island { get; set;}
        public int x { get; set;}
        public int y { get; set;}
        public double longitude { get; set;}
        public double latitude { get; set;}
        public string locality { get; set;}
    }
    
    public class WGS84Coordinates{
        public string tag { get; set; }
        public WGS84Coordinate wgs84Coodinate{ get; set;} 
    }
    
    class Sample {
        static public void Main(){
            const string json =
            @"{""174.845620 -36.913447 WGS84"":[{""uuid"":""a7e72b5c1fb96f1452d3c64fe89c7e6a"",""name"":""35 Carbine Road"",""suburb"":""Mount Wellington"",""town"":""Auckland"",""district"":""Auckland City"",""region"":""Auckland"",""island"":""North Island"",""x"":2674839,""y"":6474828,""longitude"":174.845707,""latitude"":-36.913385,""locality"":""Mount Wellington, Auckland, Auckland City""}],""174.698503 -36.788258 WGS84"":[{""uuid"":""96fb8ae43b6791f5f2b7006d8818b9ad"",""name"":""1\/248 Beach Haven Road"",""suburb"":""Birkdale"",""town"":""North Shore"",""district"":""North Shore City"",""region"":""Auckland"",""island"":""North Island"",""x"":2661988,""y"":6488992,""longitude"":174.698375,""latitude"":-36.78816,""locality"":""Birkdale, North Shore, North Shore City""}]}";
    
            dynamic json_obj =  JsonConvert.DeserializeObject(json);
            var datas = new List<WGS84Coordinates>();
            foreach(dynamic x in json_obj){
                dynamic o = x.Value[0];
                WGS84Coordinate w = new WGS84Coordinate {
                    uuid      = o.uuid,
                    name      = o.name,
                    suburb    = o.suburb,
                    town      = o.town,
                    district  = o.district,
                    region    = o.region,
                    island    = o.island,
                    x         = o.x,
                    y         = o.y,
                    longitude = o.longitude,
                    latitude  = o.latitude,
                    locality  = o.locality
                };
                datas.Add(new WGS84Coordinates {tag = x.Name, wgs84Coodinate = w });
            }
            //check
            Console.WriteLine("{0} recodes.", datas.Count);
            Console.WriteLine("tag:{0},name:{1}", datas[0].tag,datas[0].wgs84Coodinate.name);
    
        }
    }
