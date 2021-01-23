    using System;
    using System.Windows.Forms;
    
    namespace playDataAudio
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private NAudio.Wave.BlockAlignReductionStream stream = null;
    
            private NAudio.Wave.DirectSoundOut output = null;
    
            private void openFileButton_Click(object sender, EventArgs e)
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Audio File (*.mp3;*.wav)|*.mp3;*.wav;";
                if (open.ShowDialog() != DialogResult.OK) return;
    
                DisposeWave();
    
                if (open.FileName.EndsWith(".mp3"))
                {
                    NAudio.Wave.WaveStream pcm = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader(open.FileName));
                    stream = new NAudio.Wave.BlockAlignReductionStream(pcm);
                }
                else if (open.FileName.EndsWith(".wav"))
                {
                    NAudio.Wave.WaveStream pcm = new NAudio.Wave.WaveChannel32(new NAudio.Wave.WaveFileReader(open.FileName));
                    stream = new NAudio.Wave.BlockAlignReductionStream(pcm);
                }
                else throw new InvalidOperationException("Not a correct audio file type.");
    
                output = new NAudio.Wave.DirectSoundOut();
                output.Init(stream);
                output.Play();
    
                pauseButton.Enabled = true;
            }
    
            private void pauseButton_Click(object sender, EventArgs e)
            {
                if (output != null)
                {
                    if (output.PlaybackState == NAudio.Wave.PlaybackState.Playing) output.Pause();
                    else if (output.PlaybackState == NAudio.Wave.PlaybackState.Paused) output.Play();
                }
            }
    
            private void DisposeWave()
            {
                if (output != null)
                {
                    if (output.PlaybackState == NAudio.Wave.PlaybackState.Playing) output.Stop();
                    output.Dispose();
                    output = null;
                }
                if (stream != null)
                {
                    stream.Dispose();
                    stream = null;
                }
            }
    
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                DisposeWave();
            }
        }
    }
