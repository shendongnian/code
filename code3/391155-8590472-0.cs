    var subnetOctets = new SubnetConvert[4];
    for (int i = 1; i <= 4; ++i) {
        // ID of TextBox
        var textBoxId = "txtOctet" + i.ToString(CultureInfo.InvariantCulture);
        // The TextBox
        var textBox = (TextBox)FindControl(textBoxId);
        // Parse the value into an int
        int octet = int.Parse(textBox.Text);
        // Create a new SubnetConvert object
        subnetOctets[i - 1] = new SubnetConvert() { OctetConvert = octet};
        // Update the TextBox's Test
        textBox.Text = subnetOctets[i - 1].SendBinary;
    }
