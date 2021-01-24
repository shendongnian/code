    private Dictionary<string, Label> mapping = new Dictionary<string, Label>();
    public void MyForm()
    {
        InitializeComponent();
        // assuming you created the labels in design time populate your dictionary here:
        mapping["L0x7241"] = labelL0x7241;
        // ...
    }
    private void UpdateLabels(byte[] data)
    {
        string associatedWidget = GetKey(data); // whatever logic here
        mapping[associatedWidget].Text = "1111"; // change the text of the associated label
    }
