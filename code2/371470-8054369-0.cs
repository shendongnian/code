    public void SetPassword( DirectoryEntry AdEntry, string userPassword )
            {
                ADEntry.Invoke( "SetPassword", new object[] { userPassword } );
                ADEntry.CommitChanges();
            }
