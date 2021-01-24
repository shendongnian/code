csharp
var list = allDepartments
	.Where(d => departmentIds.Contains(d.Id))
	.Select(d => new Department() {
		Id = d.Id,
		Name = d.Name,
		Teachers = (d.Teachers.Any(t => teacherIds.Contains(t.TeacherId))
			? d.Teachers.Where(t => teacherIds.Contains(t.TeacherId))
			: d.Teachers)
				.Select(t => new Teacher() {
					TeacherId = t.TeacherId,
					TeacherName = t.TeacherName,
					DepartmentId = d.Id,
					Students = t.Students.Any(s => studentIds.Contains(s.StudentId))
					    ? t.Students.Where(s => studentIds.Contains(s.StudentId))
					    : t.Students
				})
	})
Would something like this work for you?
