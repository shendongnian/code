      private void Stop_Click(object sender, EventArgs e)
        {
            t.Stop();
              try
            {
                Drawing_time =  TimeSpan.Parse (labelResult.Text);
                Console.WriteLine("{0} converts to {1}.", labelResult.Text, Drawing_time.ToString());
            }
            catch (FormatException)
            {
                Console.WriteLine("{0} is not in the correct format.", labelResult.Text);
            }
             Machine_time = Drawing_time + Machine_time;
            Properties.Settings.Default.Machine_Time = Machine_time;
           MessageBox.Show(Drawing_time.ToString());
            string message = "Full Time   " + ((Machine_time)).ToString() + "\n" +"Days   " +((Machine_time.Days)).ToString() + "\n" + "Hours   "+((Machine_time.Hours)).ToString() + "\n"
             + "Minutes  " + ((Machine_time.Minutes)).ToString()+ "\n"+ "Seconds  " + ((Machine_time.Seconds)).ToString();
         MessageBox.Show(message);
            saveSettings();
        }
