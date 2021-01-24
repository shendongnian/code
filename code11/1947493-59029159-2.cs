	var Projects = (from up in ctx.usersProject join u in ctx.users
		on up.user equals u.id into uloj from uj in uloj.DefaultIfEmpty()
		where (up.deleted ?? false) == false
			&& up.projectId == p.Id
			&& (uj.deleted ?? false) == false
			select new { 
				ProjectId = up.projectId, 
				ProjectsList = uj.name + " " + uj.surname
			}).ToList();
	
	var myEnt = from p in ctx.Project.AsEnumerable()
		select new ProjectRepository.Project
		{
			Id = p.ProjectId,
			Desc = p.ProjectDesc,
			UsersProject = Projects.Where(e=> p.ProjectId == e.ProjectId).Select(e=> e.ProjectsList).FirstOrDefault())
		}).ToList();
