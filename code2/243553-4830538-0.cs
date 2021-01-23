    var projects = (from project in this.Session.Query<Project>()
                    where project.IsClosed == false
                       && project.IsVoided == false
                       && project.Parent == null 
                    select project)
                   .AsEnumerable()
                   .Concat(
                   (from project in this.Session.Query<Project>()
                    where project.IsClosed == false
                       && project.IsVoided == false
                       && project.Parent.IsVoided == false
                       && project.Parent.IsClosed == false
                    select project))
                   .ToList();
