            [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GroepsResultaten(int vakId, int[] studentId, double [] cijfers, [Bind("Id,Beoordeling,StudentId,VakId")] List<Resultaat> resultatenLijst, Resultaat resultaat)
        {
            Console.WriteLine("vakId is :" + vakId);
            if (ModelState.IsValid)
            {
                foreach (var student in studentId)
                {
                    Resultaat res = new Resultaat
                    {
                        StudentId = student,
                        Beoordeling = 3,
                        VakId = vakId
                    };
                    ////Console.WriteLine("current student is: " + student + " with grade: " + cijfer + " and subjectid: " + vakId);
                    resultatenLijst.Add(res);
                }
              
                _context.Resultaat.AddRange(resultatenLijst);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Voornaam", resultaat.StudentId);
            ViewData["VakId"] = new SelectList(_context.Set<Vak>(), "Id", "Naam", resultaat.VakId);
            return View(resultaat);
        }
