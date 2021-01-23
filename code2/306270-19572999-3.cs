        private void splitContainer1_Panel2_ClientSizeChanged(object sender, EventArgs e)
        {
            
            if (splitContainer1.Panel1Collapsed)
            {
                splitContainer2.Panel1.Cursor = Cursors.Default;
                this.btnExpand.Image =  imageExpand;
            }
            Else
           {
                splitContainer2.Panel1.Cursor = Cursors.VSplit;
                this.btnExpand.Image = imageCollapse;
          }
        }
