    // using Microsoft.Data.ConnectionUI;
    // using System.Windows.Forms;
    bool TryGetDataConnectionStringFromUser(out string outConnectionString)
    {
        using (var dialog = new DataConnectionDialog())
        {
            // If you want the user to select any of the available data sources, do this:
            DataSource.AddStandardDataSources();
        
            // OR, if you want only certain data sources to be available
            // (e.g. only SQL Server), do something like this instead: 
            dialog.DataSources.Add(DataSource.SqlDataSource);
            dialog.DataSources.Add(DataSource.SqlFileDataSource);
            …
            // The way how you show the dialog is somewhat unorthodox; `dialog.ShowDialog()`
            // would throw a `NotSupportedException`. Do it this way instead:
            DialogResult userChoice = DataConnectionDialog.Show(dialog);
            // return the resulting connection string if a connection was selected:
            if (userChoice == DialogResult.OK)
            { 
                outConnectionString = dialog.ConnectionString;
                return true;
            }
            else
            {
                outConnectionString = null;
                return false;
            }
        }
    }
