    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Teacher teacher)
        {
            //get your desired dutyId with your own logic
            var SelectedDutyIds = new int[] { 1 };
            var teacherDuties = new List<TeacherDuty>();
            if (ModelState.IsValid)
            {
                _context.Add(teacher);
                await _context.SaveChangesAsync();
                foreach (var id in SelectedDutyIds)
                {
                    var item = new TeacherDuty()
                    {
                        TeacherId = teacher.Id,
                        DutyId = id,
                    };
                    teacherDuties.Add(item);
                }
                _context.AddRange(teacherDuties);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }
