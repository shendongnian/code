    delegate void VoidDelegate();
    
    List<int> results;
    bool cancelWork = false;
    
    void DoWork() {
        int calc;
        results = new List<int>();
        
        for(int i = int.MinValue ; i < int.MaxValue; i+=10) {
            if(cancelWork) break;
            results.Add(i);
        }
        
        this.Invoke(new VoidDelegate(WorkFinished));
    }
    
    void Button1_Click(object sender, EventArgs e) {
        button1.Enabled = false;
        button2.Enabled = true;
        cancelWork = false;
        Thread t = new Thread(DoWork);
        t.Start();
    }
    
    void Button2_Click(object sender, EventArgs e) {
        button2.Enabled = false;
        cancelWork = true;
    }
    
    void WorkFinished() {
        button1.Enabled = true;
        button2.Enabled = false;
        textBox1.Text = results.Count.ToString();
    }
