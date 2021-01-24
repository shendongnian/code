     // GET: Users/Edit/5
        public async Task<IActionResult> EditTest(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user =await  _context.Users
                .Include(u=>u.Referals)
                .Include(u=>u.UserGroups).ThenInclude(ug=>ug.Group)
                .SingleOrDefaultAsync(u=>u.Id==id);
            if (user == null)
            {
                return NotFound();
            }
            var userForUpdate = _mapper.Map<UserForUpdateDto>(user);
            return View(userForUpdate);
        }
        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTest(int id, UserForUpdateDto userForUpdate)
        {
            if (id != userForUpdate.UserId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var user = _context.Users.AsNoTracking()
                        .Include(u => u.Referals)
                        .Include(u=>u.UserGroups)
                            .ThenInclude(ug => ug.Group).SingleOrDefault(u => u.Id == id);
                    _mapper.Map(userForUpdate,user);
                    
                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(userForUpdate.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userForUpdate);
        }
