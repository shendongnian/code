    using (ArchiveEntities db = new ArchiveEntities())
    {
        Employee employee = db.Employees.Single(x => x.Id == SelectedEmployee.Id);
        db.Employees.ApplyCurrentValues(employee);
        db.SaveChanges();
        View.CommitEdit();
     }
