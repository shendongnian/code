    var usersProject = (from up in ctx.usersProject join u in ctx.users
                    on up.user equals u.id into uloj from uj in uloj.DefaultIfEmpty()
                    where (up.deleted ?? false) == false
                    && up.projectId == p.Id
                    && (uj.deleted ?? false) == false
                    select new { 
                       ProjectId = up.projectId, 
                       User = uj.name + " " + uj.surname
                    }).ToList();
    var myEnt = from p in ctx.Project.AsEnumerable()
                select new ProjectRepository.Project
                {
                   Id = p.ProjectId,
                   Desc = p.ProjectDesc
                }).ToList();
     var myEntL = myEnt.ToList();
     foreach (var mysingleEnt in myEntL)
     {
        myEntL.Where(x => x.Id == mysingleEnt.Id).FirstOrDefault().utentiAssociati =
        String.Join("; ", usersProject
           .Where(x => x.ProjectId == mysingleEnt.Id).Select(x => x.User).ToList());
      }
      gridProg.DataSource = myEntL;
      gridProg.DataBind();
