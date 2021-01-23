    private void LoadComments(Member member, XElement commentsXml)
    {
        member.Comments = (from comment in commentsXml.Descendants("comment")
                         select new Comment()
                         {
                             ID = (comment.Element("id")==null)?"":comment.Element("id").Value,
                             Text = (comment.Element("text")==null)?"":comment.Element("text").Value,
                             Date = (comment.Element("date")==null)?"":comment.Element("date").Value,
                             Owner = (comment.Element("user")==null)?"":comment.Element("user").Element("name").Value
                         }).ToList();
    }
