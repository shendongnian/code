    private void LoadComments(Member member, XElement commentsXml)
    {
        member.Comments = (from comment in commentsXml.Descendants("comment")
                            select new Comment()
                            {
                                ID = comment.GetElementValue("id"),
                                Text = comment.GetElementValue("text"),
                                Date = comment.GetElementValue("date"),
                                Owner = comment.GetElement("user").GetElementValue("name")
                            }).ToList();
    }
