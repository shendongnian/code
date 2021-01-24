    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ID,Title,ReleaseDate,Genre,Price")] Movie movie)
    {    
        if (ModelState.IsValid)
        {
                //post to api here
            return RedirectToAction(nameof(Index));
        }
        return View(movie);
    }
