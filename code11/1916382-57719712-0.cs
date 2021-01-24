        public async Task<IActionResult> AssignClass()
        {
            var assignTeacherToClass = new AssignTeacherToClass {
                TeacherId = new Guid("52abe5e0-bcd4-4827-893a-26b24ca7b1c4"),
                ClassId =new Guid("50354c76-c9e8-4fc3-a7c9-7644d47a6854")
            };
            var teacher = await _context.Teachers.Include(t => t.Classes).FirstOrDefaultAsync(t => t.Id == assignTeacherToClass.TeacherId);
            var classToAssign = await _context.Classes.FindAsync(assignTeacherToClass.ClassId);
            teacher.AssignClass(classToAssign);
            _context.Entry(teacher).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(teacher);
        }
