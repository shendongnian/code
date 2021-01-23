            SPList l = SPContext.Current.Web.Lists[new Guid(ddl_Lists.SelectedValue)];
            List<string> visFields = new List<string>();
            foreach (SPField field in l.Fields)
            {
                if (!field.Hidden)
                {
                    visFields.Add(field.Title);
                }
            }
