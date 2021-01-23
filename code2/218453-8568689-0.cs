            DirectoryEntry AD = new DirectoryEntry("WinNT://" + Environment.MachineName + ",computer");
            DirectoryEntry grp;
            grp = AD.Children.Find("test", "user");
            if (grp != null)
            {
                grp.Invoke("SetPassword", new object[] { "test" });
            }
            grp.CommitChanges();
            MessageBox.Show("Account Change password Successfully");
