    public class ConnectedRepository<TEntity,T>
       where TEntity : class
       where T:class
    {
        ConnectedRepository<T> GenRep;
        public ConnectedRepository(int c)
        {
            GenRep = new ConnectedRepository<T>(c); // now sure what c is, bt you could pass it to the constructor like this, if GenRep needs it
        }
         public void LoadData()
         {
            grdData.DataSource = GenRep.ToBindingList();
         }
         public void DoStuff()
         {  // do something else with  GenRep ?
         }
     }
