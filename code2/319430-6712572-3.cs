        private float mBlend;
        private int mDir = 1;
        public int count = 0;
        public Bitmap[] pictures;
        
        public void myPhoto()
        {
            pictures = new Bitmap[9];
            pictures[0] = new Bitmap(@"Library Images\cf3.jpg");
            pictures[1] = new Bitmap(@"Library Images\cf4.jpg");
            pictures[2] = new Bitmap(@"Library Images\l1.JPG");
            pictures[3] = new Bitmap(@"Library Images\l2.JPG");
            pictures[4] = new Bitmap(@"Library Images\l3.JPG");
            pictures[5] = new Bitmap(@"Library Images\l4.JPG");
            pictures[6] = new Bitmap(@"Library Images\l5.JPG");
            pictures[7] = new Bitmap(@"Library Images\l6.JPG");
            pictures[8] = new Bitmap(@"Library Images\l7.JPG");
            timer1.Interval = 50; //time of transition
            timer1.Tick += BlendTick;
            try
            {
                blendPanel1.Image1 = pictures[count];
                blendPanel1.Image2 = pictures[++count];
            }
            catch
            {
            }
            timer1.Enabled = true;
        }
        private void BlendTick(object sender, EventArgs e)
        {
            mBlend += mDir * 0.02F;
            if (mBlend > 1)
            {
                mBlend = 0.0F;
                if ((count + 1) < pictures.Length)
                {
                    blendPanel1.Image1 = pictures[count];
                    blendPanel1.Image2 = pictures[++count];
                }
                else
                {
                    blendPanel1.Image1 = pictures[count];
                    blendPanel1.Image2 = pictures[0];
                    count = 0;
                }
            }
            blendPanel1.Blend = mBlend;
        }
