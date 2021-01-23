    public static string[] ToEfInclude(this PostAssociations[] postAssocations)
    {
        if (postAssocations == null) return null;
        List<string> includeAssociations = new List<string>();
        if (postAssocations.Contains(PostAssociations.User))
            includeAssociations.Add("User");
        if (postAssocations.Contains(PostAssociations.Comments))
        {
            if (postAssocations.Contains(PostAssociations.CommentsUser))
            {
                includeAssociations.Add("Comments.User");   
            }
            includeAssociations.Add("Comments");
        }
        return includeAssociations.ToArray();
    }
