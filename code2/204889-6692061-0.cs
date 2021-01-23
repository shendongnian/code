    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Net;
    using StreamCoders.Network;
    //using StreamCoders.Wave;
    //using StreamCoders.Encoder;
    //using StreamCoders.Decoder;
    using System.Threading;
    using StreamCoders;
    using System.IO;
    
    namespace SpeechSendReceive
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            RTPParticipant participant;
            RTPSender rtp_sender;
            RTPReceiver rtp_receiver;
            RTPSession session;
            //WaveOutput wout;
            //WaveInput win;
    
            //SpeechEncoder encoder;
            //SpeechDecoder decoder;
    
            Thread WaveInThreadProc;
    
            bool IsRunning = false;
    
            long packetsReceived;
            long packetsSent;
    
            System.Windows.Forms.Timer updateTimer = new System.Windows.Forms.Timer();
    
            private void button1_Click(object sender, EventArgs e)
            {
                button1.Enabled = false;
                IPEndPoint localEP = new IPEndPoint(IPAddress.Any, int.Parse(textBox3.Text));
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(textBox2.Text), int.Parse(textBox1.Text));
    
                participant = new RTPParticipant(localEP, remoteEP, null, null);
    
                rtp_sender = new RTPSender();
                rtp_sender.AddParticipant(participant);
    
                rtp_receiver = new RTPReceiver();
                rtp_receiver.AddParticipant(participant);
                
    
                
    
                //win = new WaveInput();
                //win.BitsPerSample = 16;
                //win.Channels = 1;
                //win.SampleRate = 8000;
                //win.TransferBufferSize = 320;
                //win.Init();
                //win.OpenDevice();
    
                WaveInThreadProc = new Thread(new ThreadStart(() =>
                    {
    
                        while (IsRunning)
                        {
                            //if (win.WaitSamplesAvailable(100))
                            Thread.Sleep(1000);
                            {
                                //byte[] pcm = win.GetNextData();
                                //var frame = encoder.EncodeToFrame(pcm);
                                //if (frame != null)
                                {
                                    var data = new byte[200];
                                    for (int i = 0 ; i < 200; i++ )
                                    {
                                        data[i] = Convert.ToByte(packetsSent + i);
                                    };
                                    session.Send(new RTPPacket(data));
    
                                    packetsSent++;
                                }
                            }
    
                        }
                    })) { Name = "WaveInputThread" };
    
    
                //wout = new WaveOutput();
                //wout.BitsPerSample = 16;
                //wout.Channels = 1;
                //wout.SampleRate = 8000;
                //wout.Init();
                //wout.OpenDevice();
    
                //encoder = new SpeechEncoder();
                //encoder.InputBitsPerSample = 16;
                //encoder.InputChannels = 1;
                //encoder.InputSampleRate = 8000;
                //encoder.OutputBitrate = 64000;
                //encoder.SetCodec(SpeechCodecs.G711A);
                //encoder.Init();
    
                //decoder = new SpeechDecoder();
                //decoder.Bitrate = 64000;
                
                //decoder.SetCodec(SpeechCodecs.G711A);
                //bool res = decoder.Init();
    
                // Set up last to avoid conflicts
    
                session = new RTPSession();
                session.AddReceiver(rtp_receiver);
                session.AddSender(rtp_sender);
                session.NewRTPPacket = OnNewPacket;
    
                IsRunning = true;
                //win.Start();
                WaveInThreadProc.Start();
    
    
                updateTimer.Interval = 500;
                updateTimer.Tick += new EventHandler(updateTimer_Tick);
                updateTimer.Start();
                
            }
    
            void updateTimer_Tick(object sender, EventArgs e)
            {
                sentLabel.Text = packetsSent.ToString();
                receivedLabel.Text = packetsReceived.ToString();
    
    
            }
    
            private string fn = string.Format(@"c:\temp\rtp{0}.snd", DateTime.Now.Millisecond);
    
            public bool OnNewPacket(RTPPacket packet, byte[] rawBuffer)
            {
                packetsReceived++;
    
                using (Stream fileStream = new FileStream(fn, FileMode.Append, FileAccess.Write, FileShare.None))
                {
                    using (BinaryWriter bw = new BinaryWriter(fileStream))
                    {
                        bw.Write(rawBuffer);
                    }
                }
    
                //var pcm = decoder.Decode(packet);
    
                //if (pcm != null)
                //{
                //    wout.Enqueue(pcm);
                //}
                return false;
            }
    
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                IsRunning = false;
            }
        }
    }
