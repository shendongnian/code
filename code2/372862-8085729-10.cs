    // Todo: This is a terrible name.
    // Figure out what makes more sense in your domain, by seeing where you use it
    public class VisibleTags
    {
        private readonly IMyContextClass context;
        public VisibleTags(IMyContextClass context)
        {
            this.context = context;
        }
        // Todo: Try to see if you can get this to return IQueryable.
        // I haven't used Union, so I'm not sure if it breaks that ability or not...
        public IEnumerable<Tag> GetVisibleTags(User user)
        {
            return context.Tags
                .Where(t => t.PrivateUserID == null)
                .Union(user.Tags)
                ;
        }
    }
