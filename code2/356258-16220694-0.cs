	using System;
	using System.Windows.Forms;
	
	namespace combotest
	{
		class MainClass
		{
			public static void Main (string[] args)
			{
				WinForm form = new WinForm ();
				Application.Run (form);
				//Console.WriteLine("Hello World!");
			}
		}
		public class WinForm : Form
		{
			public WinForm ()
			{
				InitializeComponent ();
			}
			ComboBox comboBox1;
			TextBox textBox1;
			private void InitializeComponent ()
			{
				this.Width = 400;
				this.Height = 300;
				this.Text = "My Dialog";
				Button btnOK = new Button ();
				btnOK.Text = "OK";
				btnOK.Location = new System.Drawing.Point (10, 10);
				btnOK.Size = new System.Drawing.Size (80, 24);
				this.Controls.Add (btnOK);
				btnOK.Click += new EventHandler (btnOK_Click);
				comboBox1=new ComboBox();
				comboBox1.Location = new System.Drawing.Point (10, 50);
				comboBox1.Size = new System.Drawing.Size (80, 24);
				comboBox1.DropDownStyle=ComboBoxStyle.DropDownList;
				this.Controls.Add (comboBox1);
				
				textBox1=new TextBox();
				textBox1.Location = new System.Drawing.Point (100, 50);
				textBox1.Size = new System.Drawing.Size (80, 24);
				this.Controls.Add (textBox1);
				
				this.SuspendLayout();
				String[] iList=new String[]{"text0","text1","text2","text3","text4"};
				comboBox1.Items.AddRange(iList);
				comboBox1.SelectedIndex=0;
				this.ResumeLayout();			
				comboBox1.KeyPress+=new KeyPressEventHandler(comboBox1_KeyPress);
			}
			
		    private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
		    {
		        if (e.KeyChar == (char)Keys.Tab)
		            return;
		        if (e.KeyChar.ToString().ToUpper() == "A")
		        {
		             e.Handled = true;
		             comboBox1.SelectedIndex = 2;
					textBox1.Text=comboBox1.SelectedItem.ToString();
		        }
		    }
			private void btnOK_Click (object sender, System.EventArgs e)
			{
				this.DialogResult = DialogResult.OK;
				this.Close ();
			}
			
		}
	}
	
