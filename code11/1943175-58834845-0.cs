using System.Linq;
private void SetButtonsBackColorToRed()
{
  foreach ( var button in Controls.OfType<Button>() )
    button.BackColor = Color.Red;
}
This gets all controls of the form of Button type and parse the resulting list to change the back color.
Alternative:
    Controls.OfType<Button>().ToList().ForEach(button => button.BackColor = Color.Red);
