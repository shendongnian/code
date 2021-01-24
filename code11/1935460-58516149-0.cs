        public class TestClass
        {
            public string A = "";
        }
        public class NodeModel
        {
            public double X { get; set; }
            public double Y { get; set; }
            public int ParentNumber { get; set; }
            public GeometryParams Geometry { get; set; }
            public object Props { get; set; }
        }
        public class GeometryParams
        {
            public string PropTest { get; set; }
        }
            public void TestMethod()
        {
            var nodeModel = new NodeModel()
            {
                X = 3.5,
                Y = 4.2,
                ParentNumber = 1,
                Geometry = new GeometryParams { PropTest = "value" },
                Props = new TestClass()
            };
            var json = JsonConvert.SerializeObject(nodeModel, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All,  });
            //json result
            //{ 
                //"$type":"WebApplication2.Controllers.ValuesController+NodeModel, WebApplication2",
                //"X":3.5,
                //"Y":4.2,
                //"ParentNumber":1,
                //"Geometry":{ 
                    //"$type":"WebApplication2.Controllers.ValuesController+GeometryParams, WebApplication2",
                    //"PropTest":"value"},
                //"Props":{ 
                    //"$type":"WebApplication2.Controllers.ValuesController+TestClass, WebApplication2",
                    //"A":""} 
            //}
            var nodeModel2 = JsonConvert.DeserializeObject<NodeModel>(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });
         }
