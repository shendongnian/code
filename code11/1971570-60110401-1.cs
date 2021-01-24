    [HttpPost]
    public async Task<IActionResult> Edit(PostViewModel vm)
    {
        var post = new Post
        {
            Id = vm.Id,
            Title = vm.Title,
            Body = vm.Body
        };
        if (post.Id > 0)
        {
            post.Updated = DateTime.Now;
            _repo.UpdatePost(post);
        }
        else
        {
            post.Created = DateTime.Now;
            post.Updated = DateTime.Now; // If you want Created == Updated on creation
            _repo.AddPost(post);
        }
        if (await _repo.SaveChangesAsync())
            return RedirectToAction("Index");
        else
            return View(post);
    }
