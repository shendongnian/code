    void MainGragfik_ProgressUpdate(double progress)
    {
        if (InvokeRequired)
        {
             BeginInvoke((MethodIvoker)(() =>
             {
                 MainGragfik_ProgressUpdate(progress);
             }));
             
             return;
        }
        ProgressBar = progress;
    }
