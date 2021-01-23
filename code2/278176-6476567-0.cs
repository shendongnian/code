    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using NAudio.Wave;
    using NAudio.CoreAudioApi;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form4 : Form
        {
    
            private BufferedWaveProvider bwp;
    
            WaveIn wi;
            WaveOut wo;
            public Form4()
            {
                InitializeComponent();
                wo = new WaveOut();
                wi = new WaveIn();
    
                wi.DataAvailable += new EventHandler<WaveInEventArgs>(wi_DataAvailable);
    
                bwp = new BufferedWaveProvider(wi.WaveFormat);
                bwp.DiscardOnBufferOverflow = true;
    
                wo.Init(bwp);
                wi.StartRecording();
                wo.Play();
    
            }
    
            void wi_DataAvailable(object sender, WaveInEventArgs e)
            {
                bwp.AddSamples(e.Buffer, 0, e.BytesRecorded);
    
            }
        }
    }
