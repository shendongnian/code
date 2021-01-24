    public class MySerializer
    {
        void CheckForEnums<T>(T obj)
        {
            var tpInfo = typeof(T);
    
            var list_Props = tpInfo.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    
            foreach (var prop in list_Props)
            {
                if (prop.PropertyType.IsEnum)
                {
                    var enumVals = Enum.GetValues(prop.PropertyType);
                    var first_enum = enumVals.GetValue(0);
                    prop.SetValue(obj, first_enum);
                }
            }
    
            var prop_Fields = tpInfo.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    
            // Same here but altered for fields
        }
    
        public virtual TOut DeserializeObject<TOut>(string json)
        {
            var obj_result = JsonConvert.DeserializeObject<TOut>(json);
            this.CheckForEnums(obj_result);
            return obj_result;
        }
    }
    
    
    enum X { One = 1, Two = 2 };
    
    class Y
    {
        [JsonProperty]
        X A_Field;
    
        public X A_Property { get; set; }
    }
    
    
    static void TestEnum()
    {
        var ser = new MySerializer();
        var my_obj = ser.DeserializeObject<Y>("{}");
    }
