    public partial class FormB : Form, IFormBrothers
    {
       public List<IFormBrothers> Brothers { get; set; }
    }
    
    public partial class FormA : Form, IFormBrothers
    {
       public List<IFormBrothers> Brothers { get; set; }
    }
