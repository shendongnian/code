     public void SetButtonClick(Control parent)
        {
            if (parent is Button)
            {
                    (parent as Button).Click += new EventHandler(this.Mymethod);
            }
            foreach (Control item in parent.Controls)
            {
                SetButtonClick(item);
            }
        }
