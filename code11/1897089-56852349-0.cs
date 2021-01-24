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
                    void OnProgressChanged((string Message, int Progress) args)
                    {
                        // Report progress to frm here.
                        // The following line is only for demonstration.
                        frm.Text = $@"{args.Message} {args.Progress}"; 
                    }
                    var progress = new Progress<(string Message, int Progress)>(OnProgressChanged);
                    try
                    {
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
    }
