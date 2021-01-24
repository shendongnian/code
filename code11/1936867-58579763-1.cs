using System.Reflection;
public partial class FormTest : Form
{
  private List<MethodInfo> RandomMethods = new List<MethodInfo>();
  private Random Random = new Random();
  public FormTest()
  {
    InitializeComponent();
    InitializeRandomMethods();
  }
  private void InitializeRandomMethods()
  {
    foreach ( var method in this.GetType().GetMethods() )
      foreach ( var attribute in method.GetCustomAttributes(false) )
        if ( attribute is RandomMethodAttribute )
          if ( method.ReturnType != typeof(void) || method.GetParameters().Length != 0 )
          {
            string strError = $"Bad method signature: {GetType().Name}.{method.Name}"
                            + Environment.NewLine
                            + "Must have no return type and no parameters.";
            MessageBox.Show(strError, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          else
            RandomMethods.Add(method);
  }
  [RandomMethod]
  public void s1()
  {
    textBox1.Text = "ali9090";
    textBox2.Text = "bar123";
  }
  [RandomMethod]
  public void s2()
  {
    textBox1.Text = "ali777";
    textBox2.Text = "BKardak123";
  }
  private void button4_Click(object sender, EventArgs e)
  {
    if (RandomMethods.Count > 0)
      RandomMethods[Random.Next(RandomMethods.Count)].Invoke(this, null);
    else
    {
      string strWarning = "No random method available.";
      MessageBox.Show(strWarning, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
  }
}
After the form class code or in another file:
public class RandomMethodAttribute : Attribute
{
  public RandomMethodAttribute()
  {
  }
}
