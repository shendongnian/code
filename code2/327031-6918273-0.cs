    public void StoreNames(List<string> input)
    {
        if (comboBox1.InvokeRequired)
            comboBox1.Invoke((MethodInvoker)delegate {
                StoreNames(input);
            });
        else
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(input.ToArray());
        }
    }
