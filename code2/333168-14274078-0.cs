    button.Click += (_, __) =>
    {
        // Create another thread that does something with the data object
        var worker = new BackgroundWorker();
        worker.DoWork += (___, _____) =>
        {
            for (int i = 0; i < 10; i++)
            {
                // This doesn't lead to any cross-thread exception
                // anymore, cause the binding source was told to
                // be quiet. When we're finished and back in the
                // gui thread tell her to fire again its events.
                myData.MyText = "Try " + i;
            }
        };
        worker.RunWorkerCompleted += (___, ____) =>
        {
            // Back in gui thread let the binding source
            // update the gui elements.
            bindingSource.ResumeBinding();
            button.Enabled = true;
        };
        // Stop the binding source from propagating
        // any events to the gui thread.
        bindingSource.SuspendBinding();
        button.Enabled = false;
        worker.RunWorkerAsync();
    };
