	public static void main(String[] args) {
		int param1 = 0, param2 = 0;
		getResult(param1, param2);
	}
	public static void getResult(Object param1, Object param2) {
		for (int i = 0; i < gridview.rows.count - 1; i++) {
			if (!Regex.IsMatch(RechargeText, "successfully")) {
				RechargeStatus = "Failed";
				Program.sp.SoundLocation = System.IO.Path
						.GetDirectoryName(System.Reflection.Assembly
								.GetExecutingAssembly().Location)
						+ "/aimlife_error.wav";
				Program.sp.Play();
			} else if (Regex.IsMatch(RechargeText, "Processing")
					|| Regex.IsMatch(RechargeText, "Not")) {
				// just skip here then
				continue;
			} else {
				Program.sp.SoundLocation = System.IO.Path
						.GetDirectoryName(System.Reflection.Assembly
								.GetExecutingAssembly().Location)
						+ "/aimlife_success.wav";
				Program.sp.Play();
			}
			Program.StatusMessage = "Recharge Successful";
			TextFill();
		}
	}
