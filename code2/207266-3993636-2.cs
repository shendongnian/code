    public class Data
    {
       public event EventHandler OnSave = (s,e) => 
          {
             //do something important!
          };
       public void Save()
       {
          OnSave(this,null);
          //do save
       }
    }
    //outside the class
    Data data = new Data { OnSave = null }; //compile error
    data.OnSave = SomeMethodElse;  //compile error
    data.OnSave += MyCustomActionsOnSave;  //ok
    data.Save();
