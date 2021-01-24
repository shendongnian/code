    public static void BeEquivalentToExcludingId(this ObjectAssertions objectAssertion, IEntity expectation)
    {
        var subj = (IEntity)objectAssertion.Subject;
        var subjId = subj._id;
        var expId = expectation._id;
        subj._id = ObjectId.Empty;
        expectation._id = ObjectId.Empty;
        objectAssertion.BeEquivalentTo(expectation);
        subj._id = subjId;
        expectation._id = expId;
    }
