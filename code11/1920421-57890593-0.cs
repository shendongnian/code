c#
public partial class Form1 : Form
{
    boolean _formLoading;
    private void Form1_Load(object sender, EventArgs e)
    {
        _formLoading = true;
        ...
        ...
        ...
        _formLoading = false;
    }
    private void NameSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_formLoading) return;
        ...
        ...
        ...
    }
}
