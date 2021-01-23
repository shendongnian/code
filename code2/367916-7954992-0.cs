     public void progressbar_updates(int recno)
     {
         Dispatcher.Invoke(new Action(() =>
         {
                  progressbar1.Value += recno;
                  progressbar1.UpdateLayout();
         }), DispatcherPriority.Render);
     }
