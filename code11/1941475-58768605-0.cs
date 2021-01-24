C#
// 1.st file, where the Form1 is declared:
// Place the using directive
using A2;
namespace A1
{
  public partial class Form1 : Form
  {
    public void ShowForm2()
    {
      Form2 newForm = new Form2();
      newForm.Show();
      // It works without the using directive aswell, while using following:
      A2.Form2 newForm = new A2.Form2();
      newForm.Show();
    }
  }
}
// 2.nd file, where the Form2 is declared:
namespace A2
{
  public partial class Form2 : Form
  {
    // Anything..
  }
}
