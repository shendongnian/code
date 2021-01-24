        [TestMethod]
        public void Conditions_MethodsHaveCorrectSignature()
        {
            var whitelist = new List<string> { "Finalize", "MemberwiseClone" };
            var t = typeof(Conditions);
            var m = t.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var item in m.Where(x => !whitelist.Contains(x.Name)))
            {
                Assert.AreEqual(typeof(int), item.ReturnType);
                CollectionAssert.AreEquivalent(new List<Type> { typeof(string), typeof(int), typeof(char) },
                    item.GetParameters().Select(x => x.ParameterType).ToList());
            }
        }
