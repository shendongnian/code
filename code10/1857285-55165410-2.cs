        public class PartParameters
        {
            public double bar_diameter { get; set; }
            public int core_height { get; set; }
            public double roughing_offset { get; set; }
        }
        public class RootObject
        {
            public PartParameters part_parameters { get; set; }
        }
        public static void LoadJson()
        {
            using (System.IO.StreamReader r = new System.IO.StreamReader(@"C:\part_param.json"))
            {
                string json = r.ReadToEnd();
                try
                {
                    RootObject part = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(json);
                 
                    _logger.Info(string.Format("list values : bardiameter: {0}, coreHeight: {1}, roughingOffset: {2}", 
                        part.part_parameters.bar_diameter,part.part_parameters.core_height, part.part_parameters.roughing_offset));
                }
                catch (Exception e)
                {
                    _logger.Info(string.Format("Read Json failed {0}", e.Message));
                }
            }
        }
