    try
        {
            // Opens the software key
            RegistryKey softwareKey = Registry.LocalMachine.OpenSubKey("SOFTWARE", false);
            // Opens the CetraStage key
            RegistryKey key = softwareKey.OpenSubKey("CentraStage", false);
            string connectwiseId = (string)key.GetValue("CONNECTWISEID");
            key.Close();
            MessageBox.Show(connectwiseId, "Reg Key Value", MessageBoxButtons.OK);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
