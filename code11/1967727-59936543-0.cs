            public IActionResult GroepsResultaten(int vakId, int groepId)
        {
            var studentenLijst = _context.Student.Join(_context.StudentGroep,
               s => s.Id,
               sg => sg.StudentId,
               (s, sg) => new { Student = s, StudentGroep = sg })
               .Where(x => x.StudentGroep.GroepId == groepId)
               .Select(x => x.Student)
               .ToList();
            if (groepId >= 1)
            {
                ViewData["Studenten"] = studentenLijst.ToList();
            }
            //ViewBag.Studenten = new SelectList(studentenLijst, "Id", "Naam");
            return View();
        }
