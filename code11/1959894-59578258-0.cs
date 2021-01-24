    public async Task<IActionResult> OnGetAsync(int? courseID, int? instructorID) {
      if (courseID == null || instructorID == null) {
        return NotFound();
      }
      CourseAssignment = await _context.CourseAssignments
          .AsNoTracking()
          .Include(c => c.Course)
          .Include(c => c.Instructor)
          .FirstOrDefaultAsync(m => m.CourseID == courseID && m.InstructorID == instructorID);
      if (CourseAssignment == null) {
        return NotFound();
      }
      return Page();
    }
