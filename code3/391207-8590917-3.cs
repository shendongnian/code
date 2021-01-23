    public List<Membership> Execute(string templateKey) {
        IEmailQuery query = MailQueryMap[templateKey].Invoke();
        var queryResult = query.ExecuteQuery();
        // ...
    }
