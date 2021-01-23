       private void AddNewUserControlAndAutoRemoveOldUserControl(UserControl control)
        {
            if (control != null)
            {
                Panel parent = control.Parent as Panel;
                if (parent != null)
                {
                    // Removing old UserControl if present
                    if(parent.Children.Count > 0)
                        parent.Children.RemoveAt(0);
                    parent.Children.Insert(0, control);
                }
            }
        }
