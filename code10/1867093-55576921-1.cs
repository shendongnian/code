    using LiveCharts;
    using LiveCharts.Configurations;
    using LiveCharts.Wpf;
    using System;
    using System.Windows.Forms;
    using static MindWave_Reader.ReadEEG;
    
    namespace MindWave_Reader
    {
      public partial class Form1 : Form
      {
        /// <summary>
        /// Simple class to hold an alpha value and the time it was received. Used
        /// for charting.
        /// </summary>
        public class EEGPowerAlphaValue
        {
          public DateTime Time { get; }
          public double AlphaValue { get; }
    
          public EEGPowerAlphaValue(DateTime time, double alpha)
          {
            Time = time;
            AlphaValue = alpha;
          }
        }
    
        private ReadEEG _readEEG;
    
        /// <summary>
        /// Contains the alpha values we're showing on the chart.
        /// </summary>
        public ChartValues<EEGPowerAlphaValue> ChartValues { get; set; }
    
        public Form1()
        {
          InitializeComponent();
    
          // Create the mapper.
          var mapper = Mappers.Xy<EEGPowerAlphaValue>()
              .X(model => model.Time.Ticks)   // use Time.Ticks as X
              .Y(model => model.AlphaValue);  // use the AlphaValue property as Y
    
          // Lets save the mapper globally.
          Charting.For<EEGPowerAlphaValue>(mapper);
    
          // The ChartValues property will store our values array.
          ChartValues = new ChartValues<EEGPowerAlphaValue>();
          cartesianChart1.Series = new SeriesCollection
          {
            new LineSeries
            {
              Values = ChartValues,
              PointGeometrySize = 18,
              StrokeThickness = 4
            }
          };
    
          cartesianChart1.AxisX.Add(new Axis
          {
            DisableAnimations = true,
            LabelFormatter = value => new DateTime((long)value).ToString("mm:ss"),
            Separator = new Separator
            {
              Step = TimeSpan.FromSeconds(1).Ticks
            }
          });
    
          SetAxisLimits(DateTime.Now);
        }
    
        private void StartButton_Click(object sender, EventArgs e)
        {
          _readEEG = new ReadEEG();
          _readEEG.AlphaReceived += _readEEG_AlphaReceived;
        }
    
        /// <summary>
        /// Called when a new alpha value is received from the device. Updates the
        /// chart with the new value.
        /// </summary>
        /// <param name="sender">The <see cref="ReadEEG"/> object that raised this
        /// event.</param>
        /// <param name="e">The <see cref="AlphaReceivedEventArgs"/> that contains
        /// the new alpha value.</param>
        private void _readEEG_AlphaReceived(object sender, EventArgs e)
        {
          AlphaReceivedEventArgs alphaReceived = (AlphaReceivedEventArgs)e;
    
          // Add the new alpha reading to our ChartValues.
          ChartValues.Add(
            new EEGPowerAlphaValue(
              DateTime.Now,
              alphaReceived.Alpha));
    
          // Update the chart limits.
          SetAxisLimits(DateTime.Now);
    
          // Lets only use the last 30 values. You may want to adjust this.
          if (ChartValues.Count > 30)
          {
            ChartValues.RemoveAt(0);
          }
        }
    
        private void SetAxisLimits(DateTime now)
        {
          if (cartesianChart1.InvokeRequired)
          {
            cartesianChart1.Invoke(new Action(() => SetAxisLimits(now)));
          }
          else
          {
            // Lets force the axis to be 100ms ahead. You may want to adjust this.
            cartesianChart1.AxisX[0].MaxValue =
              now.Ticks + TimeSpan.FromSeconds(1).Ticks;
    
            // We only care about the last 8 seconds. You may want to adjust this.
            cartesianChart1.AxisX[0].MinValue =
              now.Ticks - TimeSpan.FromSeconds(8).Ticks;
          }
        }
      }
    }
