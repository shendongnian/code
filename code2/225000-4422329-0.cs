    public partial class Form1 : Form
    {
       public Form1()
       {
          InitializeComponent();
          this.userControl11.EndDrag += new MyTrackbar.UserControl1.EndDragHandler(this.userControl11_EndDrag);
       }
       private void userControl11_StartDrag()
       {
          // Works
          textBox1.BackColor = Color.Red;
       }
       private void userControl11_EndDrag()
       {
          // Now also works!
          textBox1.BackColor = Color.White;
       }
    }
