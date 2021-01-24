//* The following only changes the mode, but does not lock the file
Command.CommandText = "PRAGMA locking_mode=EXCLUSIVE;";
Command.ExecuteNonQuery();
try {
    using (var cmdLock = Connection.CreateCommand())
    {
        //* The following command will force an exclusive file lock to be obtained.
        //* Although 'WHERE false' will cause the actual UPDATE to fail,
        //*   the actual statement is valid SQL and will not cause an error. 
        cmdLock .CommandText = "UPDATE Users SET Test = 'bogus' WHERE false;";
        cmdLock .ExecuteNonQuery();
    }
    //* Exclusive lock obtained
    //... free to do updates
} 
catch {
   MessageBox.Show("Failed to obtain exclusive lock, try again later.", "Lock failed")
}
        
