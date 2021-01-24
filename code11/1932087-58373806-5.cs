    using System.Linq;
    ...
    public partial class MyForm : Form {
      ...
      int number = 1;
    
      CheckBox tempCheckbox = this
        .Controls
        .Find($"checkBoxTool{number}", true) // we don't want "myform." here
        .OfType<CheckBox>()
        .FirstOrDefault();
    
      // If check box found, check it
      if (tempCheckbox != null)
        tempCheckbox.Checked = true;
