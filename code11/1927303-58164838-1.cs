c
bool Q1Button1_True, Q2Button1_True, Q3Button1_True, Q4Button1_True;
List<string> radioBtns = new List<string>(new string[] { "Q1Button1_True", "Q2Button1_True", "Q3Button1_True", "Q4Button1_True" });
foreach (string Btn in radioBtns)
{
   bool buttonVar = this.GetType().getProperty(Btn).getValue(this, null);
   buttonVar = true;
}
Another way of doing it is to use something like this:
c
bool Q1Button1_True, Q2Button1_True, Q3Button1_True, Q4Button1_True;
List<string> radioBtns = new List<string>(new string[] { "Q1Button1_True", "Q2Button1_True", "Q3Button1_True", "Q4Button1_True" });
foreach (string Btn in radioBtns)
{
   PropertyInfo buttonVar = this.GetType().GetProperty(Btn);
   buttonVar.SetValue(this, true, null);
}
Hope this helps!
