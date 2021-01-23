    // In partial Context class...
    public IEnumerable<Tag> GetVisibleTags(User user)
    {
        return Tags.Where(t => t.PrivateUserID == null)
            .Union(user.Tags)
            ;
    }
