    NHibernate.ISession session = ...
    // here we get the access to underling implementation
    NHibernate.Impl.SessionImpl sessionImpl = session
        .GetSessionImplementation() as NHibernate.Impl.SessionImpl;
    // and we can now work with action queue
    var actionQueue = sessionImpl.ActionQueue;
    // and check it
    var count               = actionQueue.InsertionsCount;
    var hasAnyQueuedActions = actionQueue.HasAnyQueuedActions;
