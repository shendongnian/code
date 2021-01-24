    private void Timer1_Tick(object sender, EventArgs e)
    {
      if ( Timer1.Interval > 3999 )
      {
        label1.Text = "4";
        Timer1.Interval = newValue1;
      }
      else
      if ( Timer1.Interval > 3000 )
      {
        label1.Text = "3";
        Timer1.Interval = newValue2;
      }
      else
      if ( Timer1.Interval > 2000 )
      {
        label1.Text = "2";
        Timer1.Interval = newValue3;
      }
      else
        DoSomething();
    }
