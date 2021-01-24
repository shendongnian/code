csharp
    public class MyClassBase<T>
    {
        public string Field1 { get; set; }
        public T Field2 { get; set; }
    }
    public class Field
    {
        public string Field21 { get; set; }
        public string Field22 { get; set; }
    }
    public class TestJsonDeserialise
    {
        public void Run()
        {
            var json1 = @"{
          'field1':'value1',
          'field2':
          {
          'field21':'value21',
          'field22':'value22'
          }
        }";
            var json2 = @"{
          'field1':'value1',
          'field2':false 
        }";
            var json = json2;
            var field2 = JObject.Parse(json)["field2"];
            object myClass = null;
            switch (field2.Type)
            {
                case JTokenType.Object:
                    myClass = GetMyClass<MyClassBase<Field>>(json);
                    break;
                case JTokenType.Boolean:
                    myClass = GetMyClass<MyClassBase<bool>>(json);
                    break;
            }
            switch (myClass)
            {
                case MyClassBase<Field> fieldResult:
                    //When FieldResult then do stuff
                    Console.WriteLine("You got an Object");
                    break;
                case MyClassBase<bool> boolResult:
                    //You got a bool back
                    Console.WriteLine("You got a bool");
                    break;
            }
        }
        public T GetMyClass<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
