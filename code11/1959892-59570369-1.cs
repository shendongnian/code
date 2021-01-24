    public async Task<IActionResult> OnPostAsync(DeleteCourseRequest request) {
      if (request == null) {
        return NotFound();
      }
    
      Course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseID == request.CourseID && c.InstructorID == request.InstructorID);
    
      if (Course != null) {
        _context.Courses.Remove(Course);
        await _context.SaveChangesAsync();
      }
    
      return RedirectToPage("./Index");
    }
