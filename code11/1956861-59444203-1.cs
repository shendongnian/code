     [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Edit([FromBody] AlbumViewModel album)
            {
                if (ModelState.IsValid)
                {
                    this._albumService.UpdateAlbum(album);
                }
                return RedirectToAction("Index");
            }
