	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Windows.Forms;
	namespace CS_Scratch_WindowsFormsApp1
	{
		public class NumericUpDownEx : NumericUpDown
		{
			string tennisAdv = "none";
			string whichNumUpDown = "unknown";
			public NumericUpDownEx()
			{
			}
			public override void UpButton()
			{
				if (Value == 0)
					Value = 15;
				else if (Value == 15)
					Value = 30;
				else if (Value == 30)
					Value = 40;
				else
					base.UpButton();
			}
			public override void DownButton()
			{
				if (Value == 40)
					Value = 30;
				else if (Value == 30)
					Value = 15;
				else if (Value == 15)
					Value = 0;
				else
					base.DownButton();
			}
			protected override void UpdateEditText()
			{
				if (Value > 40 & Value % 2 == 0)
				{
					this.Text = "Deuce";
				}
				else if (Value > 40 & Value % 2 != 0)
				{
					this.Text = "Adv";
				}
				else
				{
					this.Text = this.Value.ToString();
				}
			}
		}
	}
