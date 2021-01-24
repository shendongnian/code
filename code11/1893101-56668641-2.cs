interface IContractservice<TContract> where TContract : ContractData
{
     List<TContract> GetContracts();
}
The `where` makes it so the generic type you pass in has to be derived from `ContractData`.
You would then implement it like this:
class Shopsystem1contractservice : IContractservice<Shopsystem1contractData>
{
     public List<Shopsystem1contractData> GetContracts()
     {
     }
}
