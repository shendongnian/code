    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return View(new PostViewModel());
        }
        else
        {
            var post = _repo.GetPost((int)id);
            return View(new PostViewModel
            {
                Id = post.Id,
                Title = post.Title,
                Body = post.Body,
                Created = post.Created   // Remember the created date
            });
        }
    }
    [HttpPost]
    public async Task<IActionResult> Edit(PostViewModel vm)
    {
        var post = new Post
        {
            Id = vm.Id,
            Title = vm.Title,
            Body = vm.Body,
            Created = vm.Created   // Re-Assign the created date
        };
        if (post.Id > 0)
            _repo.UpdatePost(post);
        else
            _repo.AddPost(post);
        if (await _repo.SaveChangesAsync())
            return RedirectToAction("Index");
        else
            return View(post);
    }
