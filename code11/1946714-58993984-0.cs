    namespace dms2
    {
      public partial class main_frame : Form
      {
        private void myMethod()
        {
            FileInformationsWindow fi = new FileInformationsWindow() { current_level = -1, current_parent = -1 };
            fi.ShowDialog();
            FileInformationsWindow2 fi2 = new FileInformationsWindow2(-1, -1);
            fi2.ShowDialog();
        }
     }
     public partial class FileInformationsWindow : Form
     {
        public int current_level { get; set; }
        public int current_parent { get; set; }
        public FileInformationsWindow()
        {
        }
     }
     public partial class FileInformationsWindow2 : Form
     {
        public int current_level { get; private set; }
        public int current_parent { get; private set; }
        public FileInformationsWindow2(int currentlevel, int currentparent)
        {
            current_level = currentlevel;
            current_parent = currentparent;
        }
      }
    }
