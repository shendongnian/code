    private void B_Clicked(object sender, EventArgs e)
        {
            bumpPop.Dismiss();
            SfPopupLayout loadPop = new SfPopupLayout();
            DataTemplate loadView = new DataTemplate(() =>
            {
                SfBusyIndicator busy = new SfBusyIndicator();
                return busy;
            });
            loadPop.PopupView.ContentTemplate = loadView;
            loadPop.Show();
            if (String.IsNullOrEmpty((string)gradeSel.SelectedValue) || String.IsNullOrWhiteSpace((string)gradeSel.SelectedValue))
            {
                gradeSel.Watermark = "Please select a grade";
                loadPop.Dismiss();
                bumpPop.Show();
            }
            else
            {
                string grade = (string)gradeSel.SelectedValue;
                object val = new string[] { grade, loadPop };
                Thread thread = new Thread(MyMethod);
                thread.Start(val);
            }
        }
        private void MyMethod(object Data)
        {
            Invoke(new Action(() => UpdateApplicationUI(Data)));
        }
        private void UpdateApplicationUI(object Data)
        {
            object[] items = (object[])Data;
            string grade = items[0] as string;
            SfPopupLayout loadPop = items[1] as SfPopupLayout;
            BumpGrade(grade);
            UpdateOverallScore();
            AssList.ItemsSource = Asses;
            loadPop.Dismiss();
        }
    
