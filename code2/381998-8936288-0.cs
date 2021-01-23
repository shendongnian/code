    using System;
    namespace campusMap.Models
    {
        public interface Ijson_autocomplete
        {
            int id { get; set; }
            string name { get; set; }
            String get_json_data();
        }
    }
