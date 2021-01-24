    if (!int.TryParse(idNumber_TxtBox.Text, out var idNumber))
    {
        // input wasn't an integer, handle the error
    }
    command.Parameters.Add("@IDNumber", SqlDbType.Int).Value = idNumber;
