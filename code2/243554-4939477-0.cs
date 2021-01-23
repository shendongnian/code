    var projects = (from project in this.Session.Query<Project>()
                where project.Parent == null || (project.IsClosed == false
                   && project.IsVoided == false)
                   && (project.Parent == null 
                   || (project.Parent.IsVoided == false
                       && project.Parent.IsClosed == false))
                select project).ToList();
