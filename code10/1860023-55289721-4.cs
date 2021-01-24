	using System;
	using System.Text.RegularExpressions;
	using System.Windows.Forms;
	namespace phone_number_sanitizer
	{
		public partial class Form1 : Form
		{
			#region Variables
			string phonenumber = "";
			string[] msg = new string[] { "Enter a valid phone number.", "Other messages you may wish to include." }; // referenced by array index
			#endregion
			public Form1()
			{
				InitializeComponent();
			}
			private void Form1_Load(object sender, EventArgs e)
			{
				#region UI Setup
				txtPhone.MaxLength = 10;
				btnSubmit.Enabled = false;
				#endregion
			}
			private void txtPhone_TextChanged(object sender, EventArgs e)
			{
				/*
				txtPhone's MaxLength is set to 10 and a minimum of 10 characters, restricted to numbers, is
				required to enable the Submit button. If user attempts to paste anything other than a numerical
				sequence, user will be presented with a predetermined error message.
				*/
				if (txtPhone.Text.Length == 10) { btnSubmit.Enabled = true; } else { btnSubmit.Enabled = false; }
				if (Regex.IsMatch(txtPhone.Text, @"[^0-9]"))
				{
					DialogResult result = MessageBox.Show(msg[0], "System Alert", MessageBoxButtons.OK);
					if (result == DialogResult.OK)
					{
						txtPhone.Text = "";
						txtPhone.Focus();
                        btnSubmit.Enabled = false;
					}
				}
			}
			private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
			{
				/*
				Here, you check to ensure that an approved key has been pressed. If not, you don't add that character
				to txtPhone, you simply ignore it.
				*/
				if (Regex.IsMatch(e.KeyChar.ToString(), @"[^0-9]") && e.KeyChar != (char)Keys.Back) { e.Handled = true; }
			}
			private void btnSubmit_Click(object sender, EventArgs e)
			{
				/*
				By this phase, the Submit button could only be enabled if user provides a 10-digit sequence. You will have no
				more and no less than 10 numbers to format however you need to.
				*/
				try
				{
					phonenumber = txtPhone.Text;
					String.Format("{0:(###)###-####}", phonenumber);
				}
				catch
				{
				}
			}
		}
	}
