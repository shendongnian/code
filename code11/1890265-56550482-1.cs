	var result = db.TeacherSubjects.GroupBy(ts => ts.TeacherId).Select(gr => new 
    {
		TeacherId = gr.Key,
		Count = gr.Select(x => x.SubjectId).Distinct().ToList()
	}).ToList();
