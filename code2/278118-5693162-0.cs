			result = MessageBox.Show(message, caption, buttons);
			if (result == System.Windows.Forms.DialogResult.Yes)
			{
				// Closes the parent form.
				this.Close();
			}
