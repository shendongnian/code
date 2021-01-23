    db.Actions.GroupBy(
        p => p.Session,
        (session, actions) => new {
            Session = session,
            Actions = actions.OrderBy(p => p.Date)
        }).OrderBy(p => p.Session.Number).ToArray();
