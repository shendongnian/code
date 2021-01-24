      public void test() {
    
            if (activeview == null)
            {
                foreach (UIView view in currentView.Subviews)
                {
                    if (view.IsFirstResponder)
                    {
                        activeview = view;
                        activeview.BecomeFirstResponder();
                    }
                }
            }
    
            UITextField tempView = activeview as UITextField;
    
            if (tempView.Tag == 1)
            {
                //move up bellowTextField
            }
            else { 
                //move up tableView
            }
        }
