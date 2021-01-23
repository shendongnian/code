    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Web.Script.Serialization;
    
    
    class Program
    {
        static void Main(string[] args)
        {
    
            JavaScriptSerializer ser = new JavaScriptSerializer();
            ser.RegisterConverters(new[] { new ViewModelConverter() });
    
            var model = new ViewModel { Locations = { new Location { Name = "abc",
                Locations = { new Location { Name = "def"}}} } };
            var json = ser.Serialize(model);
    
            var clone = (ViewModel)ser.Deserialize(json, typeof(ViewModel));
        }
            
    }
    
    public class ViewModelConverter : JavaScriptConverter
    {
        
        public override IEnumerable<Type> SupportedTypes
        {
            get { return new[] { typeof(Location), typeof(ViewModel) }; }
        }
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            if (obj is ViewModel)
            {
                return new Dictionary<string, object> { { "locations", ((ViewModel)obj).Locations } };
            }
            if (obj is Location)
            {
                return new Dictionary<string, object> {
                    {"name", ((Location)obj).Name},
                    { "locations", ((Location)obj).Locations }
                };
            }
            throw new NotSupportedException();
        }
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            if (type == typeof(ViewModel))
            {
                var model = new ViewModel();
                ReadLocations(model.Locations, dictionary, serializer);
                return model;
            }
            if (type == typeof(Location))
            {
                var loc = new Location();
                if (dictionary.ContainsKey("name"))
                {
                    loc.Name = (string)dictionary["name"];
                }
                ReadLocations(loc.Locations, dictionary, serializer);
                return loc;
            }
            throw new NotSupportedException();
        }
        static void ReadLocations(LocationList locations, IDictionary<string, object> dictionary, JavaScriptSerializer serializer)
        {
            if (dictionary.ContainsKey("locations"))
            {
                foreach (object item in (IList)dictionary["locations"])
                {
                    locations.Add((Location)serializer.ConvertToType<Location>(item));
                }
            }
        }
    }
    public class Location
    {
        public string Name { get; set; }
    
        private LocationList _LocationList = new LocationList();
        public LocationList Locations { get { return _LocationList; } }
    }
    
    public class LocationList : List<Location> { }
    
    public class ViewModel
    {
        private LocationList _LocationList = new LocationList();
        public LocationList Locations { get { return _LocationList; } }
    }
