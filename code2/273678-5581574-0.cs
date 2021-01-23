    public class FormA : Form
    {
    
    private string _YourProperty = string.empty;
    
    public string YourProperty
    {
     get
     {
      return _YourProperty;
     }
     set
     {
      _YourProperty = value;
     }
    }
    
    }
    
    public class FormB : Form
    {
    
    public void ButtonClick(object sender, EventArgs args)
    {
     using (FormA oForm = new FormA)
     {
      if (oForm.ShowDialog() == DialogResult.OK)
      {
       string Variable = oForm.YourProperty;
      }
    }
    }
