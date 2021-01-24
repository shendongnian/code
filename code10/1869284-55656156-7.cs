    public class SomeSpecificReplyHandler : BaseHandler<SomeSpecificReply>
    {
        // Maybe these have dependencies of their own. That's easiest if 
        // everything gets resolved from an IoC container.
        protected override void HandleReplyContent(SomeSpecificReply content)
        {
            // do whatever
        }
    }
