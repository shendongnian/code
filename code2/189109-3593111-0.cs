    public class NoScrollRichTextBox : RichTextBox
    {
       const int WM_MOUSEWHEEL = 0x020A;
    
       protected override void WndProc(ref Message m)
       {
          // This will completely ignore the mouse wheel, which will disable zooming as well
          if (m.Msg != WM_MOUSEWHEEL)
             base.WndProc(ref m);
       }
    }
