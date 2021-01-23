         // notice that we are updating the form's title bar 10,000 times
         // directly on the UI thread
         TimedAction.Go
         (
            "Direct on UI Thread",
            () =>
            {
               for (int i = 0; i < 10000; i++)
               {
                  this.Text = "1234567890";
               }
            }
         );
         // notice that we are invoking the update of the title bar
         // (UI thread -> [invoke] -> UI thread)
         TimedAction.Go
         (
            "Invoke on UI Thread",
            () =>
            {
               this.Invoke
               (
                  new Action
                  (
                     () =>
                     {
                        for (int i = 0; i < 10000; i++)
                        {
                           this.Text = "1234567890";
                        }
                     }
                  )
               );
            }
         );
         // the following is invoking each UPDATE on the UI thread from the UI thread
         // (10,000 invokes)
         TimedAction.Go
         (
            "Separate Invoke on UI Thread",
            () =>
            {
               for (int i = 0; i < 10000; i++)
               {
                  this.Invoke
                  (
                     new Action
                     (
                        () =>
                        {
                           this.Text = "1234567890";
                        }
                     )
                  );
               }
            }
         );
