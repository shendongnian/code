    public delegate void ShowChildConsumer(Form ChildForm);
    public void ShowChild(Form ChildForm)
    {
         if (this.InvokeRequired)
            {
                var d = new ShowChildConsumer(ShowChild);
                this.Invoke(d, new object[] { ChildForm });
            }
            else
                ChildForm.ShowDialog(this);
        }
