        public static JsonResult IsJson(this ActionResult result)
        {
            Assert.IsInstanceOf<JsonResult>(result);
            return (JsonResult) result;
        }
        public static JsonResult WithModel(this JsonResult result, object model)
        {
            var props = model.GetType().GetProperties();
            foreach (var prop in props)
            {
                var mv = model.GetReflectedProperty(prop.Name);
                var expected = result.Data.GetReflectedProperty(prop.Name);
                Assert.AreEqual(expected, mv);
            }
            return result;
        }
