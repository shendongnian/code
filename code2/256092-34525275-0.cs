           var query = from name  in context.Version
                        join service in context.Service 
                        on name.ServiceId equals service.Id
                        where name.VersionId == Id
                        select new
                        {
                            service.Name
                        };
            ddlService.DataSource = query.ToList();
            ddlService.DataTextField = "Name";
            ddlService.DataBind();
            ddlService.Items.Insert(0, new ListItem("<--Please select-->"));
