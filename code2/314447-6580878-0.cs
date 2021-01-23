    int N = listbox1.Items.Count;
    for (int i=N-1; !worker.CancellationPending; i = (i+N-1) % N ) 
    {
       // this weird calculation i=(i+N-1)%N is because I'm not sure whether C# 
       // divides negative integers properly (so that the remainder is non-negative)
       // It could be i=(i-1)%N . 
       string queryhere = listBox1.Items[i].ToString();
       this.SetTextappend("" + queryhere + "\n");
       System.Threading.Thread.Sleep(500);
       worker.ReportProgress(i * 1); // by the way, there should be a percentage.
                                     // You better revise the progress reporting.
    }
    e.Cancel = true;
