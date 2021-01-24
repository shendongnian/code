    btnImportar.Click += button_Click;
    private async void button_Click(object sender, EventArgs e)
    { 
        UserDialogs.Instance.ShowLoading("Aguarde...", MaskType.Black);
        await DeleteContent();
    }
    private async Task DeleteContent()
    {
        string stm = "DELETE FROM Trender";
        using (SqliteCommand cmd2 = new SqliteCommand(stm, con))
        {
            await cmd2.ExecuteNonQueryAsync();
        }
    }
