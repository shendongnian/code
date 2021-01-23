    public partial class Form1 : Form
   {
      Form2 _form2;
      int _offset = 5;
      public Form1()
      {
         InitializeComponent();
         this.Move += new EventHandler(MoveSubForm);
         this.Resize +=new EventHandler(MoveSubForm);
      
      }
      private void Form1_Load(object sender, EventArgs e)
      {
         _form2 = new Form2();
         _form2.Show();
         MoveSubForm(this, e);
      }
      protected void MoveSubForm(object sender, EventArgs e)
      {
         if (_form2 != null)
         {
            _form2.Height = this.Height / 2;
            _form2.Width = this.Width / 3;
            _form2.Left = this.Left + this.Width + _offset;
            _form2.Top = this.Top;
         }
      }
    
    
