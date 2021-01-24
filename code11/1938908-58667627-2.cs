    private async void button_Click(object sender, RoutedEventArgs e)
    {
        const fileName = @"New.csv";
        try
        {
            File.AppendAllText(fileName, "Delta, Theta");
            for (var a=1; a<20; a++)
            {
                var text = string.Format("{0}, {1}", TGLatestData.EegPowerDelta, TGLatestData.EegPowerTheta);
                File.AppendAllText(fileName, text);
                await Task.Delay(3000);
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Broken", ex);
        }
    }
