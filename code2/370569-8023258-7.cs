    [Test, TestCaseSource("OperationTestCases")]
    public void ExecuteReturnsCorrectResult(
        IBinaryOperation operation,
        int inputX, int inputY,
        int expectedResult
        )
    {
        int actualResult = operation.Execute(inputX, inputY);
        Assert.That(actualResult, Is.EqualTo(expectedResult),
            "Expected operation: '{0}', with '{1}' and '{2}' to return '{3}'"
            , operation.Name
            , inputX
            , inputY
            , expectedResult
            );
    }
    static object[] OperationTestCases =
    {
        new object[] { new Multiply(), 0, 7, 0 },
        new object[] { new Multiply(), 3, 6, 18 },
        new object[] { new Add(), 0, 0, 0 },
        new object[] { new Add(), 5, 6, 11 },
    };
