    void Progress(int Progress)
    {
        if(this.InvokeRequired)
        {
            this.BeginInvoke(new ParametrizedThreadStart(Inv_Progress), Progress);
        }
        else
        {
            Inv_Progress(Progress);
        }
    }
    
    void Inv_Progress(object obj)
    {
        int progress = obj as int;
        // do your update progress bar work here
        
    }
