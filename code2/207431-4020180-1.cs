        [TestMethod]
        public void PropertyIntersectionBasedJoin()
        {
            List<ClassA> aObj = new List<ClassA>()
                                    {
                                        new ClassA() { AStr1 = "a" }, 
                                        new ClassA() { AStr1 = "b" }, 
                                        new ClassA() { AStr1 = "c" }
                                    };
            List<ClassB> bObj = new List<ClassB>()
                                    {
                                        new ClassB() { BStr = "b" }, 
                                        new ClassB() { BStr = "b" }, 
                                        new ClassB() { BStr = "c" }, 
                                        new ClassB() { BStr = "d" }
                                    };
            var result = xyz(aObj, bObj);
            Assert.AreEqual(2, result.Count());
            Assert.IsFalse(result.Any(a => a.AStr1 == "a"));
            Assert.IsTrue(result.Any(a => a.AStr1 == "b"));
            Assert.IsTrue(result.Any(a => a.AStr1 == "c"));
        }
