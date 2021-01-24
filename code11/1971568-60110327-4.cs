    [HttpPost]
    public async Task<IActionResult> Edit(PostViewModel vm)
    {
        var post = _repo.GetPost(vm.Id);
        if(post == null)
            post = new Post();
        post.Title = vm.Title;
        post.Body = vm.Body;
        if (post.Id > 0)
            _repo.UpdatePost(post);
        else
            _repo.AddPost(post);
        if (await _repo.SaveChangesAsync())
            return RedirectToAction("Index");
        else
            return View(post);
    }
