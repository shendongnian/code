    myForm2.SetName (firstName, lastName);
    public class Form2 : Form
    {
       public void SetName (string firstName, string lastName)
       {
          lblFirst.Text = firstName;
          lblLast.Text = lastName;
       }
       ...
