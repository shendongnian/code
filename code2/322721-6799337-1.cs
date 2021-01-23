            switch (((Pivot)sender).SelectedIndex)
            {
                case 0:
                    storyboard1.Begin();
                    storyboard2.Stop();
                    break;
                case 1:
                    storyboard2.Begin();
                    storyboard1.Stop();
                    break;
            }
        }
