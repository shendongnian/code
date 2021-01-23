    [WebMethod]
    public EnvelopeWithCount<List<Comment>> GetYourSayComments(int pageNumber,
                                                               int pageSize,
                                                               int commentTopicId)
    {
        CommentManager cm = new CommentManager();
        Envelope<List<Comment>> retrunVal = new Envelope<List<Comment>>();
        returnVal.Value = cm.GetYourSayComments(pageNumber,
                                                pageSize,
                                                commentTopicId,
                                                true);
        // Get the count of all rows however you need
        returnVal.RowCount = cm.GetYourSayComments(true).Count();
 
        return returnVal;
    }
