	public partial class Window1 : Window {
	
		// Use font as C# Code
		public void UpdateText1() {
				text1.Text      = "Hi There";
				FontFamily ff   = this.Resources["YourFontNickName"] 
                                    as FontFamily;
				if (ff == null) {
					Messagebox.Show("Wrong Font Name", "ERROR");
					return;
				}
				text1.FontFamily = ff;
				text1.FontSize   = 30;
		}
		
		...
	}
