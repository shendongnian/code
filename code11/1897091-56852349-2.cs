    public class ProgressForm : Form
    {
        private ProgressForm()
        {
        }
        public static async Task ShowAsync(Form owner, Action<IProgress<(string Message, int Progress)>> action)
        {
            owner.Enabled = false;
            try
            {
                using (var frm = new ProgressForm { StartPosition = FormStartPosition.CenterParent })
                {
                    frm.Show(owner);
                    try
                    {
                        var progress = new Progress<(string Message, int Progress)>(frm.OnProgress);
                        await Task.Run(() => action(progress));
                    }
                    finally
                    {
                        frm.Close();
                    }
                }
            }
            finally
            {
                owner.Enabled = true;
            }
        }
        private void OnProgress((string Message, int Progress) args)
        {
            // Report progress to this ProgressForm here.
            // This line is only for demonstration. Please add controls to the form.
            this.Text = $@"{args.Message} {args.Progress}%";
        }
    }
