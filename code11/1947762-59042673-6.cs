    private Task RunningTask { get; set; }
    void RefreshPhotoCollection (string path) 
    {
       IsOperationOnGoing = true;
       RunningTask = Task.Run(() =>
         {
             try { 
                  TimeIt( () =>
                              {
                              ... // Enumerate photos like before, but add the safe invoke:
    
                              SafeOperationToGuiThread(() => Photos.Add (new Photo (fileInfo.FullName););
                              },
                             4   // Must run for 4 seconds to show the user.
                        );
                  }
             catch() {}
             finally 
                 {
                   SafeOperationToGuiThread(() => IsOperationOnGoing = false);
                 }
              });
         }
