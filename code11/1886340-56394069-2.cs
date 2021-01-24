            try
            {
                Registry.CurrentUser.DeleteSubKeyTree("HTMPTK", true);                
            }
            catch (UnauthorizedAccessException U)
            {
                MessageBox.Show(U.Message);
                return false;
            }
