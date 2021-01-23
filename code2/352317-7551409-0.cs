      class Form2
      {
         public Sample MySample {get; set;}
      }
    private void setBtn_Click_1(object sender, EventArgs e)
    {
    Sample testing = new Sample();
    Form2 form2 = new Form2();
    form2.MySample = testing;
    form2.Show();
    }
