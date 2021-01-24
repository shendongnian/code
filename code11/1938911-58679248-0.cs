     private async void CSVexport_Click(object sender, RoutedEventArgs e)  //to use Await Task.Delay(ms) Option
        {
            try
            {
                SaveFileDialog saveAsfile = new SaveFileDialog();  //Save As File
                saveAsfile.InitialDirectory = @"C:\";
                saveAsfile.Title = "Save As File";
                saveAsfile.Filter = "CSV Document(*.csv)|*.csv|All Files(*.*)|*.*";
                saveAsfile.DefaultExt = "csv";
                saveAsfile.AddExtension = true;
                if (saveAsfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)  //Save As File Function
                {
                    GaugeSignal.Value = 1;
                    if (TGLatestData.PoorSignal != -1)
                    {
                        var SignalQuality = Math.Round((200D - TGLatestData.PoorSignal) / 2D, 1);
                        if (SignalQuality < 0) SignalQuality = 0;
                        GaugeSignal.Value = SignalQuality;
                        TGLatestData.PoorSignal = TGLatestData.PoorSignal;
                    }
                    SQZero.Visibility = 0;
                    CSVexport.Visibility = Visibility.Hidden;
                    FileStream filestream = new FileStream(saveAsfile.FileName, FileMode.Create, FileAccess.Write);
                    System.Windows.MessageBox.Show("CSV Writing...\nIf you want to stop Writing CSV, Click SQ to 0 Button,", "CSV Writing...", MessageBoxButton.OK, MessageBoxImage.Warning);
                    System.IO.StreamWriter file = new System.IO.StreamWriter(filestream);
                    int time = 1000;
                    file.WriteLine("Signal Quality, Delta, Theta, Alpha1, Alpha2, Beta1, Beta2, Gamma1, Gamma2, Attention, Meditation, Mental Effort, Task Familiarity, Task Difficulty, Blink Strength");
                    while (true)  //infinite loop
                    {
                        double Check_Signal_Zero_To_Stop = GaugeSignal.Value;
                        file.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}", GaugeSignal.Value, TGLatestData.EegPowerDelta, TGLatestData.EegPowerTheta, TGLatestData.EegPowerAlpha1, TGLatestData.EegPowerAlpha2, TGLatestData.EegPowerBeta1, TGLatestData.EegPowerBeta2, TGLatestData.EegPowerGamma1, TGLatestData.EegPowerGamma2, TGLatestData.Attention, TGLatestData.Meditation, TGLatestData.MentalEffort, TGLatestData.TaskFamiliarity, TGLatestData.TaskDifficulty, TGLatestData.BlinkStrength);
                        await Task.Delay(time);  //Delay Without FreezingUI (need async)
                        if (Check_Signal_Zero_To_Stop == 0)
                        {
                            file.Close();  //if you click SQ to 0, Do file.Close
                            while (true) await Task.Delay(1000000000); 
                        }
                    }
                }
            }
            catch (ApplicationException ex)
            {
                throw new ApplicationException("This Program is Get Broken", ex);
            }
        }
