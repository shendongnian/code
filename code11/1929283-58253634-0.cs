IEnumerable<ReportContractVM> result = contracts.Select(
            x => new ReportContractVM
                     {
                       ContactId = x.ContractId,
                       ContractName = x.ContractName
                     }
            );
to this:
List<ReportContractVM> list = contracts
    .Select( x => new ReportContractVM { ContractId = x.ContractId, ContractName = x.ContractName  } )
    .ToList();
