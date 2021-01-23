     private void timer1_Tick(object sender, EventArgs e)
        {
            if (!axShockwaveFlash1.IsPlaying())
            {
                Fome2 fobj = new Form2();
                this.Hide()
                fobj.show();
                
            }
            else if(axShockwaveFlash1.IsPlaying())
            {
            }
        }
