	public partial class Form1 : Form
	{
		Form2 form2 = new Form2();
		
		public Form1()
		{
			InitializeComponent();
			
			form2.ButtonClicked += new Form2.ButtonClickedOnForm2(form2_ButtonClicked);
			form2.Show();
		}
		private void form2_ButtonClicked(object sender, EventArgs e)
		{
			this.Controls.Add(new Button());
		}
	}
