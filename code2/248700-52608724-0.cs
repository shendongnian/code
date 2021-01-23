    public interface IQuery
    {
        IQuery SetSomeFields(string info);
    }
    void DoSomeQuerying(Action<IQuery> queryThing);
    mockedObject.Setup(m => m.DoSomeQuerying(It.Is<Action<IQuery>>(q => MyCheckingMethod(q)));
    private bool MyCheckingMethod(Action<IQuery> queryAction)
    {
        var mockQuery = new Mock<IQuery>();
        mockQuery.Setup(m => m.SetSomeFields(It.Is<string>(s => s.MeetsSomeCondition())
        queryAction.Invoke(mockQuery.Object);
        mockQuery.Verify(m => m.SetSomeFields(It.Is<string>(s => s.MeetsSomeCondition(), Times.Once)
        return true
    }
