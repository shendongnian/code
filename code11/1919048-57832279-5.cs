        [Test]
        public void WalkMustOnlyLast10Minutes()
        {
            Walk walk = new Walk();
            var charArray = new char[] {'w', 's', 'e', 'e', 'n', 'n', 'e', 's', 'w', 'w'};
            //Passing length instead of entire array. Checking Assert.IsTrue()
            Assert.IsTrue(walk.Walking(charArray.Length));
        }
