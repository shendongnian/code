        [TestMethod]
        public void GetAnswersForResultIs47()
        {
            List<string> listOfExpressions = findArithmeticSymbolsInNumericOrder13579ThatGivesThisResult(47);
            List<string> expected = new List<string> { "1*3+5*7+9", "-1-3*5+7*9" };
            CollectionAssert.AreEquivalent(expected, listOfExpressions);
        }
