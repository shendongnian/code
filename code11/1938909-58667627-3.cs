    private async void button_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"New.csv");
            int a = 1;
            file.WriteLine("Delta, Theta");
            while (a < 20)
            {
                file.WriteLine("{0}, {1}", TGLatestData.EegPowerDelta, TGLatestData.EegPowerTheta);
                a++;
                file.Close();
                await Task.Delay(3000);
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Broken", ex);
        }
    }
