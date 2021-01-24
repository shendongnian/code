public class Noob
{
   //Your Definition...
   public override string ToString() => this.Name;
}
Modify loop like:
//Output items to Attendance Report Listbox
foreach (Noob noob in info)
{
    report.newStudentSelectionBox.Items.Add(noob);
}
