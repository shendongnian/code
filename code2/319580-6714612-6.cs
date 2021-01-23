    this.Invoke(new Action(() =>
    {
        using (OpenFileDialog dialog = new OpenFileDialog())
        {
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Console.WriteLine(dialog.FileName);
            }
        }
    }));
