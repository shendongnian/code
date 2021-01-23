    delegate void Callback ();
    void CreateProgressBar ()
    {
       if (InvokeRequired)
       {
         Invoke (new Callback (CreateProgressBar));
       }
       else
       {
         progress_bar = CreateProgressBar ();
       }
     }
    void IncrementProgressBar ()
    {
       if (InvokeRequired)
       {
         Invoke (new Callback (IncrementProgressBar ));
       }
       else
       {
         progress_bar.IncrementProgressBar ();
       }
     }
    void DestroyProgressBar ()
    {
       if (InvokeRequired)
       {
         Invoke (new Callback (DestroyProgressBar));
       }
       else
       {
         progress_bar.Close ();
         progress_bar = null;
       }
     }
