    private void button1_Click(object sender, EventArgs e)
    {
       txtc = Observable.FromEvent<EventArgs>(textBox1, "TextChanged")
          .Throttle(TimeSpan.FromSeconds(0.5), Scheduler.Dispatcher)
    
       var t = from x in txtc 
               select textBox1.Text;
                
       t.Subscribe(x => listBox1.Items.Add(x));
    }
