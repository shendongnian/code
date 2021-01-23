    public RedControl()
    {
        //....
        protected override void OnLayout(LayoutEventArgs e)
        {
            addButtonToBase(); // modify base layout
            base.OnLayout(e);
        }
    }
