    static public void That<T>(ref T actual, IResolveConstraint expression, string message, params object[] args)
    {
        Constraint constraint = expression.Resolve();
        Assert.IncrementAssertCount();
        if (!constraint.Matches(ref actual))
        {
            MessageWriter writer = new TextMessageWriter(message, args);
            constraint.WriteMessageTo(writer);
            throw new AssertionException(writer.ToString());
        }
    }
        public virtual bool Matches<T>(ref T actual)
        {
            return Matches(actual);
        }
