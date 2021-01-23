        public class HotelContext : DynamicModel {
            public HotelContext():base("test") {
            PrimaryKeyField = "HotelID";
            TableName = "Hotel";
            }
        }
