    private async void B_Clicked(object sender, EventArgs e)
        {
            await DoWhateverwork();
        }
    private Task DoWhateverwork()
        {
            return Task.Factory.StartNew(() => 
            {
                bumpPop.Dismiss();
                SfPopupLayout loadPop = new SfPopupLayout();
                DataTemplate loadView = new DataTemplate(() =>
                {
                    SfBusyIndicator busy = new SfBusyIndicator();
                    return busy;
                });
                //if this is something will update the UI, u will neeed to invoke it like this
                this.Invoke((MethodInvoker)delegate
                {
                    loadPop.PopupView.ContentTemplate = loadView;
                    loadPop.Show(); txtTotalPrice.Text = (int.Parse(txtTotalPrice.Text) - amount).ToString();
                });
                if (String.IsNullOrEmpty((string)gradeSel.SelectedValue) || String.IsNullOrWhiteSpace((string)gradeSel.SelectedValue))
                {
                    gradeSel.Watermark = "Please select a grade";
                    loadPop.Dismiss();
                    bumpPop.Show();
                }
                else
                {
                    string grade = (string)gradeSel.SelectedValue;
                    Task.Run(() => BumpGrade(grade)).Wait();
                    UpdateOverallScore();
                    AssList.ItemsSource = Asses;
                    loadPop.Dismiss();
                }
            });
