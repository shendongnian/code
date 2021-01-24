interface IContractservice<TContract> where TContract : ContractData
{
     List<TContract> GetContracts();
}
The `where` makes it so the generic type can only be derived from `ContractData`.
You would then implement it like this:
class Shopsystem1contractservice : IContractservice<Shopsystem1contractData>
{
     public List<Shopsystem1contractData> GetContracts()
     {
     }
}
I wrote this on my Phone so maybe there are some minor typos, sorry for that.
