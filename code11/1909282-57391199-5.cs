    public static void BeEquivalentToExcludingId(this ObjectAssertions objectAssertion, IEntity expectation)
    {
        ((IEntity)objectAssertion.Subject)._id = ObjectId.Empty;
        expectation._id = ObjectId.Empty;
        objectAssertion.BeEquivalentTo(expectation);
    }
