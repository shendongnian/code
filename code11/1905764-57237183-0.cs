await Task.Run ( async () => await
    UnzipFilesAsync ( p => 
    {
       myProgressBar.BeginInvoke (new Action( () =>
                  myprogressBar.Progress = p; ));
    });
.
.
.
UnzipFilesAsync (Action<int> progressCallback) 
{
   .
   .
   .
   int percent = ...;
   progressCallback (percent);
}
