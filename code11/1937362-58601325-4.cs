public string GetTextbox1Text()
{
  return Textbox1.Text;
}
public string GetTextbox2Text()
{
  return Textbox2.Text;
}
public string SetTextbox3Text(string textNew)
{
  Textbox3.Text = textNew;
}
public class Class1
{
  public void Process(Form1 form)
  {
    string str = form.GetTextbox1Text() + ", " + form.GetTextbox2Text();
    form.SetTextbox3Text(str)
  }
}
Adapt to what you need.
