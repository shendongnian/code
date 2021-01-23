    public event EventHandler Click
            {
                add
                {
                    imageButton.Click += value;
                }
                remove
                {
                    imageButton.Click -= value;
                }
            }
