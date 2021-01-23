    public partial class _Default : System.Web.UI.Page
       {
          
           public List<TextBox> ListOfTextBoxes = new List<TextBox>();
           protected void Page_Load(object sender, EventArgs e)
           {
               // after execution this line
               FindTextBoxes(Page, ListOfTextBoxes);
               //ListOfTextBoxes will be populated with all text boxes with in the page.
    
           }
     
    
           private void FindTextBoxes(Control Parent, List<TextBox> ListOfTextBoxes)
           {
               foreach (Control c in Parent.Controls) {
                   // if c is a parent control like panel
                   if (c.HasControls())
                   {
                       // search all control inside the panel
                       FindTextBoxes(c, ListOfTextBoxes);
                   }
                   else {
                       if (c is TextBox)
                       {
                           // if c is type of textbox then put it into the list
                           ListOfTextBoxes.Add(c as TextBox);
                       }
                   }
               }
           }
       }
