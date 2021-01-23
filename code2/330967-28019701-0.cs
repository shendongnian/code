			foreach(Control ctrl in Controls)
			{
				if(ctrl is Panel)
				{
					foreach(Control rdb in ctrl.Controls)
					{
						if(rdb is RadioButton && ((RadioButton)rdb).Checked==true)
						{							
								((RadioButton)rdb).Checked=false;
						}
					}
				}
			}
		}
