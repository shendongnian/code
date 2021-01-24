cs
class Manager
{
   private List<IDAO> daoList = new List<IDAO<IBusinessObject>>(); // add type parameter for IDAO
   daoList.Add(new BankAccountDAO());
   daoList.Add(new CategoryDAO());
   public void myMethod(IBusinessObject b) // has to be IBusinessObject; 
                                           //you'll need to cast the underlying 
                                       ///type to promote it to a BankAccount or Category.
   {
      daoList.ElementAt(0).Save(b); // this should call the implemented Save() method of BankAccountDao
   }
}
