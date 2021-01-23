    public class StackOverflow_7521821
    {
        [XmlRoot(ElementName = "GeocodeResponse", Namespace = "")]
        public class GeocodeResponse
        {
            [XmlElement(ElementName = "status")]
            public GeocodeResponseStatusCode Status;
            [XmlElement(ElementName = "result")]
            public List<GeocodeResponseResult> Results;
        }
        [XmlType(Namespace = "")]
        public class GeocodeResponseResult
        {
            [XmlElement(ElementName = "type")]
            public List<string> Types;
            [XmlElement(ElementName = "formatted_address")]
            public string FormattedAddress;
            [XmlElement(ElementName = "address_component")]
            public List<GeocodeResponseAddressComponent> AddressComponents;
            [XmlElement(ElementName = "geometry")]
            public GeocodeResponseResultGeometry Geometry;
        }
        [XmlType(Namespace = "")]
        public class GeocodeResponseAddressComponent
        {
            [XmlElement(ElementName = "long_name")]
            public string LongName;
            [XmlElement(ElementName = "short_name")]
            public string ShortName;
            [XmlElement(ElementName = "type")]
            public List<string> Types;
        }
        [XmlType(Namespace = "")]
        public class GeocodeResponseResultGeometry
        {
            [XmlElement(ElementName = "location")]
            public Location Location;
            [XmlElement(ElementName = "location_type")]
            public GeocodeResponseResultGeometryLocationType LocationType;
            [XmlElement(ElementName = "viewport")]
            public GeocodeResponseResultGeometryViewport Viewport;
        }
        [XmlType(Namespace = "")]
        public class GeocodeResponseResultGeometryViewport
        {
            [XmlElement(ElementName = "southwest")]
            public Location Southwest;
            [XmlElement(ElementName = "northeast")]
            public Location Northeast;
        }
        public enum GeocodeResponseStatusCode
        {
            OK, 
            ZERO_RESULTS, 
            OVER_QUERY_LIMIT, 
            REQUEST_DENIED, 
            INVALID_REQUEST,
        }
        public enum GeocodeResponseResultGeometryLocationType
        {
            ROOFTOP,
            RANGE_INTERPOLATED,
            GEOMETRIC_CENTER,
            APPROXIMATE,
        }
        [XmlType(Namespace = "")]
        public class Location
        {
            [XmlElement(ElementName = "lat")]
            public string Lat;
            [XmlElement(ElementName = "lng")]
            public string Lng;
        }
        public static void Test()
        {
            XmlSerializer xs = new XmlSerializer(typeof(GeocodeResponse));
            WebClient c = new WebClient();
            byte[] response = c.DownloadData("http://maps.googleapis.com/maps/api/geocode/xml?address=1+Microsoft+Way,+Redmond,+WA&sensor=true");
            MemoryStream ms = new MemoryStream(response);
            GeocodeResponse geocodeResponse = (GeocodeResponse)xs.Deserialize(ms);
            Console.WriteLine(geocodeResponse);
            c = new WebClient();
            response = c.DownloadData("http://maps.googleapis.com/maps/api/geocode/xml?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&sensor=true");
            ms = new MemoryStream(response);
            geocodeResponse = (GeocodeResponse)xs.Deserialize(ms);
            Console.WriteLine(geocodeResponse);
        }
    }
