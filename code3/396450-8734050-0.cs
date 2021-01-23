    DateTime dtLastUpdate = DateTime.MinValue;
    
    while (condition)
    {
        DoSomeWork();
        if (DateTime.Now - dtLastUpdate > TimeSpan.FromSeconds(2))
        {
            _form.Invoke(() => {textBox.Text = myStringBuilder.ToString()});
            dtLastUpdate = DateTime.Now;
        }
    }
