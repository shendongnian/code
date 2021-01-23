    //Inside your CommentsApiController, for example
    public IEnumerable<Comment> Get(int id)
    {
        var comments = _commentsService.Get(int id);    //Call lower layers to get the data you need
        return comments;
    }
