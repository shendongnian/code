<Grid>
   <ProgressBar Name="myProgressBar"
                Minimum="0" 
                Value="{Binding ProgressBarValue,Mode=OneWay,UpdateSourceTrigger=PropertyChanged}" 
                Maximum="100"
                Foreground="{Binding ColorState,Mode=OneWay,UpdateSourceTrigger=PropertyChanged}"
                Background="#424242"
                BorderBrush="Transparent"
                BorderThickness="0"/>
   <TextBlock Text="{Binding ElementName=myProgressBar, Path=Value,Mode=OneWay,UpdateSourceTrigger=PropertyChanged, StringFormat={}{0:0}%}" 
              FontWeight="DemiBold"
              HorizontalAlignment="Center"
              VerticalAlignment="Center" />
</Grid>
**ViewModel:**
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Threading;
namespace YourNameSpace.Models
{
    public class Device : INotifyPropertyChanged
    {
        public Device()
        {
		    this.ProgressBarValue = 50; // Your ProgressBar Foreground will be "GREEN" automatically
										// This is the 
		}
        
        private double progressBarValue;
        public double ProgressBarValue
        {
            get { return progressBarValue; }
            set 
			{ 
			    progressBarValue = value; 
				if(progressBarValue < 50)
				    this.ColorState = "Red";
				else if (progressBarValue >= 50)
					this.ColorState = "Green";
			    NotifyPropertyChanged("ProgressBarValue"); 
			}
        }
        private string colorState = "Transparent";
        public string ColorState
        {
            get { return colorState; }
            set { colorState = value; NotifyPropertyChanged("ColorState"); }
        }
		
		public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string Obj)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(Obj));
            }
        }
    }
}
You can **REMOVE** this from your code:
    void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        pbStatus.Value = e.ProgressPercentage;
        int perc = Convert.ToInt32(pbStatus.Value);
        UpdateProgress(perc);
    }
    public void UpdateProgress(int percentage)
    {
        pbStatus.Value = percentage;
        if (percentage == 100)
        {
            Close();
        }
    }
And **ONLY** use this:
for (int i = data.progressBarCounter; i < 100; i++)
{
    ProgressBarValue = i;
}
Your
>ProgressBar Value
>Progress Foreground Color
will be updated **automatically**.
