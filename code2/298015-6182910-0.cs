     class MyForm : Form
     {
        Histogram one;
    public void buttonCreate_Click(object sender, EventArgs e)
    {
        int size;
        int sizeI;
        string inValue;
        inValue = textBoxSize.Text;
        size = int.Parse(inValue);
        inValue = comboBoxSizeI.Text;
        sizeI = int.Parse(inValue);
        one = new Histrograph(size, sizeI);  // NOTE THE CHANGE FROM YOUR CODE
    }
    public void buttonAddValue_Click(object sender, EventArgs e)
    {
        int dataV = 0;
        string inValue;
        inValue = textBoxDataV.Text;
        dataV = int.Parse(inValue);
        one.AddData(dataV); //using the object
    }
