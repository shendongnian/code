    private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
            {
                if ((e.Item as Product).Price == 20)
                {
                    e.Accepted = true;
                }
                else
                {
                    e.Accepted = false;
                }
            }
