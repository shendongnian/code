//I have list of students
string [] names = {"name","name2","name3","name4","name5","name6"};
// enumerator
var nameEnumerator = names.GetEnumerator();
//This is how I indentify DGV
foreach (Control grid in Pan.Controls)
{
    if (grid is DataGridView)
    {
        DataGridView myGrid = grid as DataGridView;
        // check if we still have names
        if (nameEnumerator.MoveNext())
        {
          mygrid.Rows.Add(studentId, nameIterator.Current);
        }
    }
}
