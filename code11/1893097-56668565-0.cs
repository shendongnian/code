    public interface IContractService<TData> whree TData : ContractData
    {
        List<TData> GetContracts()
    }
    
    public Shopsystem1ContractService : IContractService<Shopsystem1ContractData> {   
        List<Shopsystem1ContractData> GetContracts(){...}
    }
    
    public Shopsystem2ContractService : IContractService<Shopsystem2ContractData> {
        List<Shopsystem2ContractData> GetContracts(){...}    
    }
    
    public Shopsystem3contractservice : IContractservice<Shopsystem3ContractData> {
        List<Shopsystem3ContractData> GetContracts(){...}    
    }
