    public class DeleteEventArgs:EventArgs{
        public DeleteEventArgs(int index){
            _index = index;
        }
        private readonly int _index;
        public int Index{get{return _index;}}
    }
    public class DeleteDB
    {
         public event EventHandler<DeleteEventArgs> Deleted;
         public void Delete(int index)
         {
                if(Deleted!=null)  {
                      Deleted(this,new DeletedEventArgs(index));
                }
          }
     }
      void Test()
      {
          DBWrapper dbw = new DBWrapper();
          Console.WriteLine(dbw.GetList);
          //Apple=1,Banana=2,Cake=3
          
          DeleteDB ddb = new DeleteDB();
          ddb.Deleted += dbw.OnDeleted;            
          ddb.Delete(1);
          Console.WriteLine(dbw.GetList);
          //Banana=2,Cake=3
       }
