    private void button17_Click(object sender, EventArgs e)
    {
        // call the newly created method instead (with the XML argument null)
        HandleClickOperation(null);
    }
    private void button21_Click(object sender, EventArgs e)
    {
        // call the newly created method instead (with the XML argument set)
        HandleClickOperation(MyXmlString);
    }
    private void HandleClickOperation(string xmlString)
    {
        if (xmlString == null)
        {
            // do things unique to button17 behavior
        }
        else
        {
            // do things unique to button21 behavior
        }
        // the logic that was in button17_Click()
    }
