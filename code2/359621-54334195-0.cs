    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using CameraDevice;
    using AForge.Video.DirectShow;
    using System.Threading;
    namespace CameraCaptureTest3
    {
        public partial class Form1 : Form
        {
            CameraImaging camImg;
            bool StopVideo = true;
            Thread thrVideo;
            object mImageLock;
            FilterInfoCollection videoDevices;
            public Form1()
            {
                InitializeComponent();
                camImg = new CameraImaging();
                mImageLock = new object();
                // enumerate video devices
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                cbCameraDevices.Items.Clear();
                foreach(FilterInfo i in videoDevices) cbCameraDevices.Items.Add(i.Name);
            }
            //---------------------------------------------------------
            // VideoRecordin() is meant to be run on a separate thread
            //---------------------------------------------------------            private void VideoRecording()
            {
                camImg.videoSource.Start();
                while (!StopVideo)
                {
                    lock (mImageLock)
                    {
                        Bitmap tmp = (Bitmap)camImg.bitmap.Clone();
                        if (InvokeRequired)
                        {
                            BeginInvoke(new MethodInvoker(() =>
                            {
                                pictureBox1.Image = tmp;
                                pictureBox1.Invalidate();
                            }));
                        }
                        else
                        {
                            pictureBox1.Image = tmp;
                            pictureBox1.Invalidate();
                        }
                    }
                    Thread.Sleep(33);
                }
                camImg.videoSource.Stop();
            }
            private void btnStartVideo_Click(object sender, EventArgs e)
            {
                StopVideo = false;
                try
                {
                    camImg.videoSource = new VideoCaptureDevice(camImg.videoDevices[cbCameraDevices.SelectedIndex].MonikerString);
                    thrVideo = new Thread(VideoRecording);
                    thrVideo.Start();
                    Thread.Sleep(1000);
                    lblRecording.Visible = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("No camera is chosen.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                StopVideo = true;
                if (thrVideo != null) thrVideo.Join();
                lblRecording.Visible = false;
                Application.DoEvents();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                StopVideo = true;
                if (thrVideo != null)
                    while (thrVideo.ThreadState == ThreadState.Running)
                        Application.DoEvents();
                pictureBox1.Image = null;
                lblRecording.Visible = false;
            }
            private void button2_Click(object sender, EventArgs e)
            {
                Clipboard.SetImage(pictureBox1.Image);
            }
        }
    }
