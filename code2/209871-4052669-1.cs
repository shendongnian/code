        [Test]
        public void Test3()
        {
            count = 0;
            ICachedEnumerable<MyClass> yieldResult = GetYieldResult(1).AsCachedEnumerable();
            var firstGet = yieldResult.First();
            var secondGet = yieldResult.First();
            Assert.AreEqual(1, firstGet.Id);
            Assert.AreEqual(1, secondGet.Id);
            Assert.AreEqual(1, count);//calling "First()" 2 times, yieldResult is created 2 times
            Assert.AreSame(firstGet, secondGet);//and created different instances of each list item
        }
