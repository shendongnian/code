            [TestCase(1,2,3)] // whatever test cases make sense for you
            [TestCase(4,5,6)]
            [TestCase(7,8,9)]
            [Test]
            public void Test_InsertInt_OK( int testId, int testValue, int expectedValue)
            {
                InsertInt(testId, testValue);
                Assert.AreEqual( GetInt(testId), expectedValue )
            }
