    this.ViewModel = new FancyClassViewModel();
    this.radioButton1.CheckedChanged +=
        delegate { this.ViewModel.Radio1Checked = this.radioButton1.Checked; };
    this.radioButton2.CheckedChanged +=
        delegate { this.ViewModel.Radio2Checked = this.radioButton2.Checked; };
    this.ViewModel.PropertyChanged += (sender, e) =>
    {
        if (e.PropertyName == "Radio1")
        {
            this.radioButton1.Checked = this.ViewModel.Radio1Checked;
        }
        if (e.PropertyName == "Radio2")
        {
            this.radioButton2.Checked = this.ViewModel.Radio2Checked;
        }
    };
