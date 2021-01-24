public static Variables variabs {get;set;}
public Form2()
{
  variabs = new variables();
  InitializeComponent();
}
private void AddInvoice_Click(object sender, EventArgs e)
{
 try
 {
  variabs.rhifAnfoneb.Add(variables.rhifAnfoneb[variables.rhifAnfoneb.Length - 1] + 1);
 }
.
.
}
*To Access from Form1*
public Form1()
{
   var variablesForm1 = Form2.variabs;
}
