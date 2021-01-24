    [HttpGet("public/{orgId}")]
    public async Task<ActionResult<List<PostModel>>> GetAllPublicPostsByOrgId(string orgId)
    {
        List<PostModel> posts = await _postRepository.GetAllPostsByOrgId(orgId);
        var authorSetTasks = new List<Task>();
        foreach(var post in posts)
        {
            authorSetTasks.Add(SetAuthor(post));
        }
        await Task.WhenAll(authorSetTasks);
        return Ok(from post in posts where post.Published select post);
    }
    private async Task SetAuthor(PostModel post)
    {
        UserModel author = await _userRepository.GetUserById(post.AuthorId);
        UserModel saveAuthor = new UserModel();
        saveAuthor.FirstName = author.FirstName;
        saveAuthor.LastName = author.LastName;
        post.Author = saveAuthor;
    }
