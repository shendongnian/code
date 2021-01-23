    public static class JsonExtensions {
        public static T As<T>(this JObject jobj) {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(jobj));
        }
        public static List<T> ToList<T>(this JArray jarray) {
            return JsonConvert.DeserializeObject<List<T>>(JsonConvert.SerializeObject(jarray)); 
        }
    }
        [Test]
        public void TestDeserializeRootObject() {
            var json = @"{ id: 1, name: ""Dwight"" }";
            var jfoo = JsonConvert.DeserializeObject(json);
            var foo = (jfoo as JObject).As<Foo>();
            Assert.AreEqual(1, foo.Id);
            Assert.AreEqual("Dwight", foo.Name);
        }
        [Test]
        public void TestDeserializeArray() {
            var json = @"[
                { id: 1, name: ""Dwight"" }
                , { id: 2, name: ""Pam"" }
            ]";
            var foosArr = JsonConvert.DeserializeObject(json);
            Assert.IsInstanceOf<JArray>(foosArr);
            Assert.AreEqual(2, (foosArr as JArray).Count);
            
            var foos = (foosArr as JArray).ToList<Foo>();
            Assert.AreEqual(2, foos.Count);
            var foosDict = foos.ToDictionary(f => f.Name, f => f);
            Assert.IsTrue(foosDict.ContainsKey("Dwight"));
            var dwight = foosDict["Dwight"];
            Assert.AreEqual(1, dwight.Id);
            Assert.AreEqual("Dwight", dwight.Name);
            Assert.IsTrue(foosDict.ContainsKey("Pam"));
            var pam = foosDict["Pam"];
            Assert.AreEqual(2, pam.Id);
            Assert.AreEqual("Pam", pam.Name);
        }
