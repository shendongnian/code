    public void UpdateUserTags(User user,ICollection<Tag> taglist)
    {
        datacontext.Attach(user);
        user.Tags = new List<Tag>(user.Tags.Union(taglist));
        datacontext.SaveChanges();
    }
