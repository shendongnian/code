    private Task RunningTask { get; set; }
    void RefreshPhotoCollection (string path) 
    {
       IsOperationOnGoing = true;
       RunningTask = Task.Run(() =>
         {
             try { ... // Enumerate photos like before, but add the safe invoke:
                   SafeOperationToGuiThread(() => Photos.Add (new Photo (fileInfo.FullName););
 
                  }
             catch() {}
             finally 
                 {
                   SafeOperationToGuiThread(() => IsOperationOnGoing = false);
                 }
              });
         }
