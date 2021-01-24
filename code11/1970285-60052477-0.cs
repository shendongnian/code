    var result2Tables = _customerRepository.Table.Join(_sourcedefinitionepository.Table, c => c.SouceCode , s => s.SourceCode,
                    (c, s) => new
                    {
                        Customer = c, 
                        SourceName = s
                    })).Where(p => p.Customer.SirketKod == 1 && p.SourceName .UretimKanali == "E")
    var result = result2Tables.Join(_branchdefinitionepository.Table, p => p.Customer.BranchCode, b => b.BranchCode, (r, b) => new 
       {
          Customer = r, 
          SourceName = r.SourceName.LongName, 
          b.BranchName 
       }) 
