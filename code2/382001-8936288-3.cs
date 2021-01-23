    namespace campusMap.Models
    {
        [ActiveRecord(Lazy=true)]
        public class place_types : json_autocomplete<place_types>, campusMap.Models.Ijson_autocomplete
        {
            private int place_type_id;
            [PrimaryKey("place_type_id")]
            virtual public int id
            {
                get { return place_type_id; }
                set { place_type_id = value; }
            }
            private string Name;
            [Property]
            virtual public string name
            {
                get { return Name; }
                set { Name = value; }
            }
            private string Attr;
            [Property]
            virtual public string attr
            {
                get { return Attr; }
                set { Attr = value; }
            }
            private IList<place> places;
            [HasAndBelongsToMany(typeof(place), Lazy = true, Table = "place_to_place_models", ColumnKey = "place_model_id", ColumnRef = "place_id", Inverse = true, NotFoundBehaviour = NotFoundBehaviour.Ignore)]
            virtual public IList<place> Places
            {
                get { return places; }
                set { places = value; }
            }
        }
    }
