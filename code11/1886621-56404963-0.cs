    public int sum = 0;
    
    private void button1_Click(object sender, EventArgs e)
    {      
      sum += Convert.ToInt32(LbCount.Text);
      LbSum.Text = Convert.ToString(sum);
    }
