    public class SomeClass
    {
      private WorkerThing _newWin;
      private void DoStuff()
      {
        _newWin = new WinWorkers_AddWorker();
        _newWin.WindowState = this.WindowState;
        _newWin.Show();
      }
    }
