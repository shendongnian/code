            RegistryKey key = Registry.CurrentUser.OpenSubKey("HTMPTK");
            try
            {
                if (key != null)
                {
                    Registry.CurrentUser.DeleteSubKeyTree("HTMPTK", true);
                }
            }
            catch (UnauthorizedAccessException U)
            {
                MessageBox.Show(U.Message);
                return false;
            }
