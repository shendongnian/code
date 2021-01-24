    TheModel model = new TheModel();
    using(MigrationDB db = new MigrationDB())
    {
        model.TheList = db.Plane.Select(m => new SelectListItem()
                        {
                            Value = m.PlaneId.ToString(), //Value can hold only string
                            Text = m.PlaneName //this is the <option>text</option>
                        }.ToList();
    }
