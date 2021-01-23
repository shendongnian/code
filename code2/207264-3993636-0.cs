    public class Test
    {
       public EventHandler OnSave;
       public void Save()
       {
          OnSave(null,null);
       }
    }
    //in main method
    Test t = new Test { OnSave = (s,e) => Console.WriteLine("got it"); };
    t.Save();
