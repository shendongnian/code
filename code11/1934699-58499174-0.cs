csharp
UserDialogs.Instance.ShowLoading("Aguarde...", MaskType.Black);
ThreadPool.QueueUserWorkItem(_ => {
    string stm = "DELETE FROM Trender";
    using (SqliteCommand cmd2 = new SqliteCommand(stm, con))
    {
        cmd2.ExecuteNonQuery();
    }
    Activity.RunOnUiThread(() => {
        // Dismiss the dialog
    })
})
