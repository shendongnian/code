public string GetTextbox1Text()
{
  return Textbox1.Text;
}
public string GetTextbox2Text()
{
  return Textbox2.Text;
}
public string SetTextbox3Text(string str)
{
  Textbox3.Text = str;
}
public class Class1
{
  public void Process(Form1 form)
  {
    form.SetTextbox3Text(form.GetTextbox1Text() + ", " + form.GetTextbox2Text())
  }
}
Adapt to what you need.
