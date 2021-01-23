        private void AddTableTitles()
        {
            TableHeaderCell site  = new TableHeaderCell();
            TableHeaderCell name  = new TableHeaderCell();
            TableHeaderCell type  = new TableHeaderCell();
            TableHeaderCell model = new TableHeaderCell();
            TableHeaderRow  th    = new TableHeaderRow();
                        
            site.Controls.Add(AddSiteHeader());            
            th.Controls.Add(site);
            //AssignPlaceHolder.Controls.Add(th);
            name.Controls.Add(AddMachNameHeader());            
            th.Controls.Add(name);
            //AssignPlaceHolder.Controls.Add(th);
            type.Controls.Add(AddMachTypeHeader());            
            th.Controls.Add(type);
            //AssignPlaceHolder.Controls.Add(th);
            model.Controls.Add(AddMachModelHeader());            
            th.Controls.Add(model);
            AssignPlaceHolder.Controls.Add(th);
        }
