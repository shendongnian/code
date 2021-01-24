        public class PanelUnScrollable : Panel
        {       
            protected override void WndProc(ref Message m)
            {           
                if(m.Msg == 0x20a) return; 
                base.WndProc(ref m);
            }
        }
