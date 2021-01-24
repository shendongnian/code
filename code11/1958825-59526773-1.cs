    public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
          
            var instructor = await _context.Instructors
                .Include(i => i.OfficeAssignment)
                .FirstOrDefaultAsync(i => i.ID == id);
            //modified code shown below
            var officeAssignment = await _context.OfficeAssignments
                .FirstOrDefaultAsync(oa => oa.InstructorID == instructor.ID);
            _context.Entry(instructor).Property("RowVersion").OriginalValue = Instructor.RowVersion;
            _context.Entry(officeAssignment).Property("RowVersion").OriginalValue = Instructor.OfficeAssignment.RowVersion;
            if (await TryUpdateModelAsync<Instructor>(
                instructor,
                "Instructor",
                i => i.FirstMidName, i => i.LastName,
                i => i.HireDate, i => i.OfficeAssignment))
            {
                try
                {
                    UpdateInstructorCourses(_context, selectedCourses, instructor);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var exceptionEntry = ex.Entries.Single();
                    if (exceptionEntry.Entity.GetType() == typeof(OfficeAssignment))
                    {
                        //configure error for OfficeAssignment type
                        throw;
                    }
                    else
                    {
                        //configure error for Instructor type
                        var exceptionEntity = (Instructor)exceptionEntry.Entity;
                        var databaseValues = await exceptionEntry.GetDatabaseValuesAsync();
                        if (databaseValues == null)
                        {
                            return HandleNotFound(instructor);
                        }
                        var databaseEntity = (Instructor)databaseValues.ToObject();
                        databaseEntity.OfficeAssignment = officeAssignment;
                        SetErorMessage(exceptionEntity, databaseEntity);
                        Instructor.RowVersion = databaseEntity.RowVersion;
                        ModelState.Remove("Instructor.RowVersion");
                    }
                }
               
            }
            PopulateAssignedCourseData(_context, instructor);
            return Page();
        }
