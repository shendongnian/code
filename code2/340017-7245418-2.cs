    private static void DoSerializationTest()
        {
            string entity="{\"key0\":\"john\",\"key2\":\"ann\",\"key1\":\"joe\"}";
            JavaScriptSerializer js = new JavaScriptSerializer();
            
            Dictionary<string,string> result= js.Deserialize<Dictionary<string,string>>(entity);
            foreach (var item in result)
            {
                Console.WriteLine("Value: "+item.Value);
                Console.WriteLine("Key :"+item.Key);
            }
        }
