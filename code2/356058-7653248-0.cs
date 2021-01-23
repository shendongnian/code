    private void NewJobEventHandler(JobInfo newJob)
    {
        TreeViewItem tvItem = new TreeViewItem();
        string header = "Job: " + newJob.ToString();
    
        //The following call is what causes the exception, yet I've used very
        //similar code to update the .Text property of a TextBox from another
        //thread
        OutputDataTree.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    (Action)(() => { 
                                      TreeViewItem tvItem = new TreeViewItem();
                                      tvItem.Header = header;
                                      OutputDataTree.Items.Add(tvItem); 
                                   }));
    }
