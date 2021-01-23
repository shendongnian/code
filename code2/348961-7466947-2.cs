    [TestMethod()]
    public void AgentWithNoNameIsInvalid()
    {
        Agent target = new Agent();
        Assert.IsFalse(IsValid(target));
    }
