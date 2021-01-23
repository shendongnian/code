    public class WinApiHelper
    {
        private const UInt32 MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const UInt32 MOUSEEVENTF_LEFTUP = 0x0004;
        [DllImport("user32.dll")]
        private static extern void mouse_event(
            UInt32 dwFlags, // motion and click options
            UInt32 dx, // horizontal position or change
            UInt32 dy, // vertical position or change
            UInt32 dwData, // wheel movement
            IntPtr dwExtraInfo // application-defined information
            );
        public static void SendClick(Point location)
        {
            Cursor.Position = location;
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, new System.IntPtr());
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, new System.IntPtr());
        }     
    }
    private void toolBtnNote_Click(object sender, EventArgs e)
    {
            dropDownClosed = false;
            noteChanged = false;
              
            dgvMarks.Focus();
            tsdd = new ToolStripDropDown();
            this.tsdd.Opened += new EventHandler(tsdd_Opened);
            this.tsdd.AutoSize = true;
            NoteEdit ne = new NoteEdit();
            ne.NoteText = note ?? "";
            ne.OkClick += new NoteEdit.NoteEditEvent(ne_OkClick);
            ne.CancelClick += new NoteEdit.NoteEditEvent(ne_CancelClick);
            this.tbh = new ToolStripControlHost(ne, "noteEdit");
            this.tbh.Padding = new Padding(0);
            this.tbh.AutoSize = false;
            this.tbh.Size = ne.Size;
            this.tsdd.Items.Add(tbh);
            this.tsdd.Padding = new Padding(0);
            this.tsdd.Closing += new ToolStripDropDownClosingEventHandler(tsdd_Closing);
            this.tsdd.Show(dgvMarks, cellRect.Location + new Size(0, cellRect.Height));
            // emulate click on richtextbox at dropdown 
            WinApiHelper.SendClick(tsdd.Location + new Size(ne.Rtb.Location) + new Size(5, 5));
            while (!this.dropDownClosed)
            {
                Application.DoEvents();
            }
            if (noteChanged)
            {...}
     }
