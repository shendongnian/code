        private void CheckActiveChildForm(Form FormControl, string FormExists)
        {
            int h = 0;
            if (MdiChildren.Count() == 0)
            {
                //Form2 childF = new Form2();
                FormControl.MdiParent = this;
                FormControl.Show();
            }
            if (MdiChildren.Count() > 0)
            {
                for (int i = 0; i < MdiChildren.Count(); i++)
                {
                    if (MdiChildren.ElementAt(i).Text == FormExists)
                    {
                        h = 1;
                    }
                }
            }
            if (h == 0)
            {
                FormControl.MdiParent = this;
                FormControl.Show();
            }
        }
