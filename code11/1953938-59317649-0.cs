    static readonly object _object = new object();  
    [HttpPost]
    public async Task<Result> AddCarrierToTransfer(CarrierToTransferModel carrierModel)
    {
        Result result = new Result(true);
        try
       {
            lock (_object)  
            {  
                var pdb = new PdbEntities();
                using (var ts = await pdb.Database.BeginTransactionAsync())
                {
                    var carrier = await pdb.Carrier.FindAsync(carrierModel.Id);
                    if(carrier.Status == (int)CarrierStatus.Sold)
                    {
                        result.IsSucceed = false;
                        result.Message = "Cannot add to transfer, carrier status is sold.";
                        return result;
                     }
                    // Do other works
                    await pdb.SaveChangesAsync();
                    ts.Commit();
                }
            }
        }
        catch (Exception e)
        {
            result.IsSucceed = false;
            result.Message = e.Message;
        }
        return result;
    }
