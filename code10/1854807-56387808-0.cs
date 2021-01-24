    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    using System.Diagnostics;   // for Process, Stopwatch
    using NAudio.Wave;    // for WaveOut, WaveIn
    using NAudio.Wave.SampleProviders;  // for SignalGenerator
    namespace Speaker_Record-Wave
    {
        public partial class Form1 : Form
        {
            // 0) StopWatch
            Stopwatch stopWatch;
    
            // 1) Signal Gen -> Speaker
            WaveOut waveOut;
            SignalGenerator signalGenerator;
    
            // 2) MIC -> Wave
            WaveIn waveIn;
            WaveFileWriter waveFileWriter;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void bt_Start_Click(object sender, EventArgs e)
            {
                // 0) StopWatch
                stopWatch = new Stopwatch();
                stopWatch.Start();
    
                // 1) Signal Gen -> Speaker
                Start_Signal();
    
                // 3) Timer_Sweep
                timer_Sweep.Interval = 1500;
                timer_Sweep.Enabled = true;
    
                // 2) MIC -> Wave
                Start_Record();
            }
    
            private void timer_Sweep_Tick(object sender, EventArgs e)
            {
                // 3) Timer_Sweep
                timer_Sweep.Enabled = false;
    
                // 1) Signal Gen -> Speaker
                waveOut.Stop();
    
                // 2) MIC -> Wave
                waveIn.StopRecording();
    
                // 4) 공통
                waveOut.Dispose();
                waveIn.Dispose();
                waveFileWriter.Dispose();
    
                // 0) StopWatch
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                string es = String.Format("{0:00}:{1:00}:{2:00}:{3:00}",ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
    
                tb_Result.AppendText(es + "\n");
            }
    
            private void bt_Open_Folder_Click(object sender, EventArgs e)
            {
                Process.Start(".\\");   // Open Folder
            }
    
            ////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////////
    
            // 1) Signal Gen -> Speaker
            private void Start_Signal()
            {
                signalGenerator = new SignalGenerator();
                signalGenerator.Type = SignalGeneratorType.Sweep;
                signalGenerator.Frequency = 50;
                signalGenerator.FrequencyEnd = 5000;
                signalGenerator.SweepLengthSecs = 1.5;
    
                waveOut = new WaveOut();
                waveOut.DeviceNumber = 0;
                waveOut.Init(signalGenerator);
                waveOut.Play();
            }
    
            // 2) MIC -> Wave
            private void Start_Record()
            {
                waveIn = new WaveIn();
                waveIn.DeviceNumber = 0;
                waveIn.WaveFormat = new WaveFormat(44100, 16, 1);
    
                waveIn.DataAvailable += OnDataAvailable;
                waveIn.RecordingStopped += OnRecordingStopped;
    
                waveFileWriter = new WaveFileWriter("1_Recorded.wav", waveIn.WaveFormat);
    
                waveIn.StartRecording();
            }
    
            // 2) MIC -> Wave
            private void OnDataAvailable(object sender, WaveInEventArgs e)
            {
                if (waveFileWriter != null)
                {
                    waveFileWriter.Write(e.Buffer, 0, e.BytesRecorded);
                }
            }
    
            // 2) MIC -> Wave
            private void OnRecordingStopped(object sender, StoppedEventArgs e)
            {
                waveIn.Dispose();
                waveFileWriter.Dispose();
            }
        }
    }
