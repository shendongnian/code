    private void ExtendFormHeight()
            {
                int heightChanged = txtText.PreferredSize.Height - txtText.ClientSize.Height;
                if (Height + heightChanged > MinHeight)
                {
                    Height += heightChanged;
                }
                else
                {
                    Height = MinHeight;
                }
            }
