    public async Task<IActionResult> Create([Bind("Title,SendToSubscribers")] ArticleDto articleDto)
    {
        if (ModelState.IsValid)
        {
            var article =_mapper.Map<Article>(articleDto); // AutoMapper here
            //Here you can use articleDto.SendToSubscribers as you want
            await _articleRepository.AddAsync(article);//Example
            return RedirectToAction(nameof(Index));
        }
        return View(article);
    }
