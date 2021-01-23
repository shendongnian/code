        public void MyTest()
        {
            var json = new {Success = "Ok"};
            dynamic dynObj = new MyDynamic(json);
            Assert.AreEqual(dynObj.Success, "Ok");
        }
