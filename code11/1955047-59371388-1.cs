        public class PanelUnScrollable : Panel
        {
            public bool ScrollDisabled { get; set; }
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == 0x20a && ScrollDisabled) return;             
                base.WndProc(ref m);
            }
        }
