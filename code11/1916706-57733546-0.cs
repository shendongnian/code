    public RedLuserinterface()
    {   
        .....
        // Remove these lines 
        // SolidBrush redBrush = new SolidBrush(Color.Red);
        // Graphics circle = this.CreateGraphics();
        // circle.FillEllipse(redBrush, 0, 0, 200, 200)
        .... 
        exitBut.Click += new EventHandler(stoprun);
        this.Paint += onFormPaint;
        // No more needed here
        // redBrush.Dispose(); 
        // circle.Dispose()
    }
    private void onFormPain(object sender, PaintEventArgs e)
    {
        SolidBrush redBrush = new SolidBrush(Color.Red);
        e.Graphics.FillEllipse(redBrush, 50,250, 200, 200);
        redBrush.Dispose();
    }
