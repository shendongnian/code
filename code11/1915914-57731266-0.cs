    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        _DBC = new SMRC_DispatcherEntities();
        _DBC.Modules.Load();
        _DBC.Members.Load();
        this.moduleBindingSource.DataSource = _DBC.Modules
                                                    .OrderBy(d => d.ModuleName)
                                                    .ToList();
        this.memberBindingSource.DataSource = _DBC.Members
                                                  .OrderBy(m => m.FirstName)
                                                  .ThenBy(m => m.LastName)
                                                  .ToList();
        InitializeForm();
        moduleBindingSource.ResetBindings(false);   //  <== This fixes the issue!
    }
