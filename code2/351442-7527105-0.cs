    var input = DateTextBox.Text;
    if (!string.IsNullOrEmpty(input))
    {
        DateTime date;
        if (DateTime.TryParse(input, out date))
        {
            if (date <= DateTime.Now)
            {
                //bingo!
            }
        }
    }
