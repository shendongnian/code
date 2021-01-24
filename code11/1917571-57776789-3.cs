    private async void BtnImportURLs_Click(object sender, EventArgs e)
    {
        OpenFileDialog ofd = new OpenFileDialog
        {
            InitialDirectory = @"C:\",
            Title = "Select URLs file ...",
            DefaultExt = "txt",
            Filter = "txt files (*.txt)|*.txt",
            FilterIndex = 2,
        };
        if (ofd.ShowDialog() == DialogResult.OK)
        {
			foreach(string s in File.ReadLines(ofd.FileName))
			{
				await ProcessUrl(s, comboBoxSelectMassMacroTemplate.Text);
			}
        }
    }
	
	private async Task ProcessUrl(string Url, string SelectedMassMacroTemplate)
	{
		var input_url = Url;
        var platform = SelectedMassMacroTemplate;
		
		if (platform == "platform-[buddypress].txt")
        {
			string root_domain = Helpers.GetRootUrl(input_url);
			if (!File.Exists(@"Macros\MassMacros\" + root_domain + ".txt"))
			{
				await File.WriteAllTextAsync(@"Macros\" + Helpers.GetRootUrl(input_url) + ".txt", txtBoxPlatformMassMacro.Text.Replace("%DOMAIN%", Helpers.GetRootUrl(input_url)));
				txtBoxMassMacroOutput.AppendText($"[{DateTime.Now}] - " + Helpers.GetBuddyPressFlags(input_url) + " - " + Helpers.GetRootUrl(input_url));
				txtBoxMassMacroOutput.AppendText(Environment.NewLine);
			}
		}
	}
