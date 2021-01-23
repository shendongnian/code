            Timer T = new Timer();
            T.Interval = 10;
            T.Tick += (s, e) =>
            {
                myForm.Size = new System.Drawing.Size(myForm.Width + 10, myForm.Height);
                if (myForm.Size.Width >= FormWidthThreashold)
                    T.Stop();
            };
            T.Start();
