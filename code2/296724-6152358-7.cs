    interface IShowable
    {
        void Show();
    }
    class Contact : IShowable
    {
        public void Show() { /* ... */ }
    }
    protected void AddNewForm(IShowable o)
    {
        try
        {
            o.Show();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
