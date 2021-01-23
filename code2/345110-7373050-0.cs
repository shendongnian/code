    public class Landscape
    {
        public int Population { get; set; }
        public string Area { get; set; }
        public int TrimAndConvert()
        {
            /* Your Code to trim and convert to int */
        }
    }
    data.OrderBy(landscape => landscape.Area.TrimAndConvert());
