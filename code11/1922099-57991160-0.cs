    public async Task<List<Commission>> FetchAsync(Agent agent)
        {
            return await _agentsContext.ScanCommDoc
              .Include(x => x.CommissionStatement)
              .Where(x => x.AgentId == agent.AgentId && x.Type == FileType.CommissionStatement
                 && x.CommissionStatement.PaymentYear == x.ScanDate.AddMonths(-1).Year
                 && x.CommissionStatement.PaymentMonth == x.ScanDate.AddMonths(-1).Month)
                 .Select(x => new { x.ScanDate, x.FileUrl, x.FileGuid,  commission = (x.CommissionStatement.Amount + x.CommissionStatement.Vat) })
                 .GroupBy(x => new { x.FileGuid, x.FileUrl, x.ScanDate })
                         .Select(p => new AgentCommission
                         {
                             FileGuid = p.Key.FileGuid,
                             FileUrl = p.Key.FileUrl,
                             ScanDate = p.Key.ScanDate,
                             Commission = p.Sum(x => x.commission)
                         })
                 .OrderByDescending(x => x.ScanDate).Take(10).ToListAsync();
        }
