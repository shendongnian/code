    class ViewModel : INotifyPropertyChanged
    {
      private ObservableCollection<double> spectrumData;
      public ObservableCollection<double> SpectrumData
      {
        get => this.spectrumData;
        set
        {
          if (Equals(value, this.spectrumData)) return;
          this.spectrumData = value;
          OnPropertyChanged();
        }
      }
    
      // Constructor
      private void ViewModel()
      {
        // Initialize the data binding source of the ListView
        this.SpectrumData = new ObservableCollection<double>();
      
        // Creating an instance of Progress<T> captures the current 
        // SynchronizationContext (UI context) to prevent cross threading when updating the ProgressBars (ObservableCollection)
        IProgress<double> progressReporter = new Progress<double>(value => this.SpectrumData.Add(value));
    
        // Set timer interval to 50 ms
        var sampleRateTimer = new System.Threading.Timer(OnTimerElapsed, progressReporter, 0, 50);
      }
    
      // Timer callback
      private void OnTimerElapsed(Object progressReporter)
      {    
        //Get FFT Data
        int ret = BassWasapi.BASS_WASAPI_GetData(_fft, (int)BASSData.BASS_DATA_FFT8192);
        if (ret < -1) return;
        this.SpectrumData.Clear();
        double x, y;
        double b0 = 0;
    
        //Calculate FFT data to Frequency
        for (x = 0; x < _lines; x++)
        {
          float peak = 0;
          double b1 = Math.Pow(2, x * 10.0 / (_lines - 1));
          if (b1 > 1023) b1 = 1023;
          if (b1 <= b0) b1 = b0 + 1;
          for (; b0 < b1; b0++)
          {
            if (peak < _fft[1 + b0]) peak = _fft[1 + b0];
          }
          y = (Math.Sqrt(peak) * 3 * 255 - 4);
          if (y > 255) y = 255;
          if (y < 0) y = 0;
    
          // Update the spectrum bars of the UI
          (progressReporter as IProgress<double>).Report(y);
        }
      }
    }
