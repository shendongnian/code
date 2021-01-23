    using EdmLib; //Enterprise PDM Reference
          private void button10_Click(object sender, EventArgs e) //Check Drawing Into PDM Change State "Roll to Standard"
        {
            //Create a file vault interface and log in to a vault. 
            EdmVault5 vault = default(EdmVault5);
            vault = new EdmVault5();
            vault.LoginAuto("Engineering", 0);
            //Get the vault's root folder interface. 
            IEdmFile5 file = default(IEdmFile5);
            IEdmFile5 file2 = default(IEdmFile5);
            IEdmFolder5 folder = default(IEdmFolder5);
            folder = vault.RootFolder;
            //Check In Assembly
            file2 = vault.GetFileFromPath("file location", out folder);
            file2.UnlockFile(0, "Checked In By Configurator", 0, null);
            //Check In Drawing and Change State to "Roll to Standard"
            file = vault.GetFileFromPath("file location", out folder);
            file.UnlockFile(0, "Checked In By Configurator", 0, null);
            file.ChangeState("Check ENG Design", folder.ID, "Created By Configurator", 0 , 0);
            file.ChangeState("Final Review", folder.ID, "Created By Configurator", 0, 0);
            file.ChangeState("Roll to Standard", folder.ID, "Created By Configurator", 0, 0);
            MessageBox.Show(textBox1.Text + " Drawing and Assembly Checked-In");
        }
