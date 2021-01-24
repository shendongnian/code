NAudio.Wave.WaveFileWriter waveWriter = null;
            WaveIn wi = new WaveIn();
            double[] primArray = new double[samples.Length];
            for (int i = 0; i < samples.Length; i++)
            {
                primArray[i] = Convert.ToDouble(samples[i].Real);
            }
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Wave File (*.wav)|*.wav;";
            if (save.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            wi = new NAudio.Wave.WaveIn();
            wi.WaveFormat = new WaveFormat(samplingRate,1);
            waveWriter = new WaveFileWriter(save.FileName, wi.WaveFormat);
            byte[] byteArray = new byte[samples.Length*8];
            byteArray = doubleToBytes(primArray);
            waveWriter.Write(byteArray, 0, byteArray.Length);
