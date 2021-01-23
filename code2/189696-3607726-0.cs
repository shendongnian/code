    btn.Click += yourMethod;
    
    private void yourMethod(object sender, EventArgs e)
    {
        // your implementation
        Button btn = sender as Button;
        if (btn != null)
        {
            //use btn
        }
    }
