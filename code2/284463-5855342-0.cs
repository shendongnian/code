    for (int i = 0; i < 30; i++)
    {
       if (symptom1.Checked && symptom2.Checked)
       {
          Result.Text += Environment.NewLine + "Your Disease is: " + "Meningiomas";
       }
    
       if (symptom7.Checked && symptom8.Checked)
       {
          Result.Text += Environment.NewLine + "Your Disease is: " + "Pituitary Tumor";
       }
    }
