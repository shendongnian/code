    // In partial User class...
    public IEnumerable<Tag> GetVisibleTags(MyContextClass context)
    {
        return context.Tags.Where(t => t.PrivateUserID == null)
            .Union(this.Tags)
            ;
    }
