            switch (((Pivot)sender).SelectedIndex)
            {
                case 0:
                    storyboard1.Start();
                    storyboard2.Stop();
                    break;
                case 1:
                    storyboard2.Start();
                    storyboard1.Stop();
                    break;
            }
        }
