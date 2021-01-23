        ...
        stopwatch.Start();
        timerLabel.Visible = true;
        progressBar1.Maximum = SequenceListBox.Items.Count;
        progressBar1.Step = (progressBar1.Maximum / SequenceListBox.Items.Count);
        progressBar1.PerformStep();
        foreach(ElementControl item in SequenceListBox.Items)
        {
            item.RunElement();
            Application.DoEvents();
        }
        stopwatch.Stop();
        ...
