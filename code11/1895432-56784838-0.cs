                for each(Window win in Application.Current.Windows)
                {
                    string windowType = win.GetType().ToString();
                    if (!windowType.Equals(nameSpace + "." + ABC))
                    {
                       ABC abc= new ABC();
                       abc.Show();
                    }
                }
         
