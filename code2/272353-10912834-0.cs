        public partial class Form1 : Form
        {
            Video video;
            Int SeqNo = 0;
    
            public Form1()
            {
                InitializeComponent();          
                Initializevid1();
    
            }
        
            public void Initializevid1()
            {
        
                   // store the original size of the panel
                    int width = viewport.Width;
                    int height = viewport.Height;
        
                    // load the selected video file
                    video = new Video(listbox1.Items[SeqNo].Text);
        
                    // set the panel as the video object’s owner
                    video.Owner = viewport;
        
                    // resize the video to the size original size of the panel
                    viewport.Size = new Size(width, height);   
                    // stop the video
                    video.Play();
                    // start next video
                    video.Ending +=new EventHandler(BackLoop);
            }
        
            private void BackLoop(object sender, EventArgs e)
            {
                // increment sequence number
                SeqNo += 1;            //or '++SeqNo;'
    
                //check video state
                if (!video.Disposed)
                {
                    video.Dispose();
                }
                //check SeqNo against listbox1.Items.Count -1 (-1 due to SeqNo is a 0 based index)
                if (SeqNo <= listbox1.Items.Count -1)
                {
                   
                   // store the original size of the panel
                    int width = viewport.Width;
                    int height = viewport.Height;
        
                    // load the selected video file
                    video = new Video(listbox1.Items[SeqNo].Text);
        
                    // set the panel as the video object’s owner
                    video.Owner = viewport;
        
                    // resize the video to the size original size of the panel
                    viewport.Size = new Size(width, height);   
                    // stop the video
                    video.Play();
         
                    // start next video
                    video.Ending +=new EventHandler(BackLoop);
               }
            }
        
