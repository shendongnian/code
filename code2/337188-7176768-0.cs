     protected override MyDataContext CreateDataSource()
        {
            _mdc = new MyDataContext(@"blablalba") { TablePrefix = "vcrm_" };
            _mdc.Configuration.ValidateOnSaveEnabled = false;
            return _mdc;
        }
