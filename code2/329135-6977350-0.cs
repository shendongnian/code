    catch (Exception err)
        {
            MessageBox.Show("User {0}. Message {1}", 
                             System.Security.Principal.WindowsIdentity.GetCurrent().Name, 
                             err.Message);
        }
