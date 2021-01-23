      public class MouseOver
      {
        public void mouseOver(Label label1, ToolTip ttpTemp)
        {
                        ttpTemp.AutoPopDelay = 2000;
                        ttpTemp.InitialDelay = 1000;
                        ttpTemp.ReshowDelay = 500;
                        ttpTemp.IsBalloon = true;
                        ttpTemp.SetToolTip(label1, "Message1");
                        ttpTemp.Show("message1", label1,label1.width,label1.height/10,5000);
          }
       }
