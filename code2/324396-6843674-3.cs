    namespace WindowsApplication1 
    {
       public partial class Form1 : Form
       {
          private float mBlend;
          private int mDir = 1;
          public Form1()
          {
             InitializeComponent();
             timer1.Interval = 30;
             timer1.Tick += BlendTick;
             blendPanel1.Image1 = Bitmap.FromFile(@"c:\temp\test1.bmp");
             blendPanel1.Image2 = Bitmap.FromFile(@"c:\temp\test2.bmp");
             timer1.Enabled = true;
          }
          private void BlendTick(object sender, EventArgs e)
          {
             mBlend += mDir * 0.02F;
             if (mBlend < 0) { mBlend = 0; mDir = 1; }
             if (mBlend > 1) { mBlend = 1; mDir = -1; }
             blendPanel1.Blend = mBlend;
          }
       }
    }
