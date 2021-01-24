    public IHttpActionResult GetUser(int id)
    {
        User user = _db.User.Find(id);
        return new HtmlResult(user);
    }
