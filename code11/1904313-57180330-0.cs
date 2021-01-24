    public bool Create(ConfiguratedMachine entity)
            {
                int addedRecords;
                using (var ctx = _dbContext)
                {
                    var cus = ctx.Customers.Find(3);
                    ctx.Customers.Attach(cus);
                    var configMachine = entity.ToContextModel();
                    configMachine.Customer = cus;
                    var configmach = ctx.ConfiguratedMachines.Add(configMachine);
                    addedRecords = ctx.SaveChanges();
                }
                return addedRecords > 0;
            }
