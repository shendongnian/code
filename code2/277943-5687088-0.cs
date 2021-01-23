    class FormPanel : Panel
    {
        bool previous;
        public FormPanel()
        {
            previous = false;
            base.Parent = this;
            base.Dock = DockStyle.Fill;
        }
    }
