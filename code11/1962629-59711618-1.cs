     [HttpPost]
     [ValidateAntiForgeryToken]
     public async Task<IActionResult> Edit(long id, Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                   //your new dutyIds
                    var newSelectedDutyIds = new int[] { 3 };
                    var teacherDuties = new List<TeacherDuty>();
                   
                    var tdList = await _context.TeacherDuties.Where(td => td.TeacherId == teacher.Id).ToListAsync() ;
                    _context.RemoveRange(tdList);
                    foreach (var newid in newSelectedDutyIds)
                    {
                        var item = new TeacherDuty()
                        {
                            TeacherId = teacher.Id,
                            DutyId = newid,
                        };
                        teacherDuties.Add(item);
                    }
                    _context.AddRange(teacherDuties);
                    _context.Update(teacher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(teacher.Id))
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
            return View(teacher);
        }
