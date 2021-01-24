            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Edit(AlbumViewModel model)
            {
                if (ModelState.IsValid)
                {
                    this._albumService.UpdateAlbum(model);
                }
                return RedirectToAction("Index");
            }
