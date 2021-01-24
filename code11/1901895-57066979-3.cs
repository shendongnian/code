    [Serializable]
    public class ContractSummaryViewModel
    {
        public int ContractId { get; set; }
        public string ContractNumber { get; set; }
        public decimal Amount { get; set; }
    }
    var contracts = _dbContext.Contracts
        .Where(c => c.VendorID == vendorId)
        .Select( c => new ContractSummaryViewModel
        {
            ContractId = c.ContractId,
            ContractNumber = c.ContractNumber,
            Amount = c.Amount
        })
        .ToList();
