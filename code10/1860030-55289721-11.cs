	using System;
	using System.Text.RegularExpressions;
	using System.Windows.Forms;
	namespace phone_number_sanitizer
	{
		public partial class Form1 : Form
		{
			#region Variables
			string phonenumber = "";
			string[] msg = new string[] { "Enter a valid phone number.", "Other messages you may wish to include." };
			#endregion
			public Form1()
			{
				InitializeComponent();
			}
			private void Form1_Load(object sender, EventArgs e)
			{
				#region UI Setup
				txtPhone.MaxLength = 13;
				btnSubmit.Enabled = false;
				#endregion
			}
			private void txtPhone_TextChanged(object sender, EventArgs e)
			{
				if (txtPhone.Text.Length == 10 && Regex.IsMatch(txtPhone.Text, @"[0-9]")
				{
					btnSubmit.Enabled = true;
					txtPhone.Text = txtPhone.Text.Insert(6, "-").Insert(3, ")").Insert(0, "(");
					txtPhone.SelectionStart = txtPhone.Text.Length;
					txtPhone.SelectionLength = 0;
				}
				else if (txtPhone.Text.Length == 13 && Regex.IsMatch(txtPhone.Text, @"\([0-9]{3}\)[0-9]{3}\-[0-9]{4}"))
				{
					btnSubmit.Enabled = true;
				}
				else
				{
					btnSubmit.Enabled = false;
					txtPhone.Text = txtPhone.Text.Replace("(", "").Replace(")", "").Replace("-", "");
					txtPhone.SelectionStart = txtPhone.Text.Length;
					txtPhone.SelectionLength = 0;
				}
			}
			private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
			{
				if (Regex.IsMatch(e.KeyChar.ToString(), @"[^0-9]") && e.KeyChar != (char)Keys.Back) { e.Handled = true; }
			}
			private void btnSubmit_Click(object sender, EventArgs e)
			{
				try
				{
					phonenumber = txtPhone.Text;
				}
				catch { /* There's nothing to catch here so the try / catch is useless. */}
			}
		}
	}
