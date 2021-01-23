    [TestMethod]
            public void GetAnswersForResultIs47()
            {
                List<string> listOfExpressions = findArithmeticSymbolsInNumericOrder13579ThatGivesThisResult(47);
                Assert.AreEqual(true, listOfExpressions.Contains("1*3+5*7+9"));
                Assert.AreEqual(true, listOfExpressions.Contains("-1-3*5+7*9"));
            }
