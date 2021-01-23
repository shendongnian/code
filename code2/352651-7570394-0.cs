    protected void dsContracts_Deleting1(object sender, EntityDataSourceChangingEventArgs e)
    {
        ipiModel.Contract ct = (ipiModel.Contract)e.Entity;
        using (var db = new ipiModel.ipiEntities())
        {
            var contract = db.Contracts.Where(c => c.ContractID == ct.ContractID).Single();
            File.Delete(Path.Combine(ConfigurationManager.AppSettings["ContractUploadPath"], contract.FileName));
        }
    }
	
