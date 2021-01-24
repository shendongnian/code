private string _element1;
public string Element1
{
  get
  {
    return _element1;
  }
  set 
  {
   element1 = value;
    OnPropertyChanged(nameof(Element1));
  }
}
Set it as: `Element1 = config.Requires[0];`
And then use it to set the TextBox as follows: `checkBox2.DataBindings.Add(new Binding("Checked", Element1, ""));`
