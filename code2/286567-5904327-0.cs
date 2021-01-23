            List<Person> ps = new List<Person>();
            DropDownList dl = new DropDownList();
            dl.Items
               .AddRange(ps
                .Select(p => new ListItem() {
                   Text = p.Name
                   , Value = p.ID
                   , Selected = p.Selected }).ToArray());
