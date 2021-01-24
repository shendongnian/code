        private async void frmMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try{
                string msg = "Do you want to exit this application?";
                Classes.DialogService dS = new Classes.DialogService();
                e.Cancel = true;
                MessageDialogResult dr = await dS.ShowMessage(msg, MessageDialogStyle.AffirmativeAndNegative, "Exit Application");
                if (dr == MessageDialogResult.Affirmative){
                    Application.Current.Shutdown();
                }
            }
            catch (Exception ex){
                Console.WriteLine("Message: " + ex.Message.ToString());
            }
        }
