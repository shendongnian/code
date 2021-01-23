    var subnetOctet = new SubnetConvert();
    for (int i = 1; i <= 4; ++i) {
        // ID suffix as string
        var indexText = i.ToString(CultureInfo.InvariantCulture);
        // ID of TextBox and Label
        var textBoxId = "txtOctet" + indexText;
        var labelId = "lblOctet" + indexText;
        // The TextBox and the Label
        var textBox = (TextBox)FindControl(textBoxId);
        var label = (Label)FindControl(labelId);
        // Parse the value into an int
        int octet = int.Parse(textBox.Text);
        subnetOctet.OctetConvert = octet;
        // Update the TextBox's Test
        label.Text = subnetOctet.SendBinary;
    }
