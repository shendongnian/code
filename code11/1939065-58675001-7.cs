public partial class PersonControl : UserControl
{
  public PersonControl()
  {
    InitializeComponent();
  }
  public PersonControl(Person person) : this()
  {
    pictureBox.Image = Image.FromFile(person.pathImage);
    labelName.Text = person.Prenom + " " + person.Nom;
    labelMail.Text = person.mail;
    labelPhone.Text = person.tel;
  }
}
int x = 0;
int y = 0;
for ( int i = 0; i < contacts.Count; i++ )
{
  var control = new PersonControl(contacts[i]);
  control.Location = new Point(x, y);
  panel.Controls.Add(control);
  y += control.Height;
}
You should take care of the file image size that must be the same for all and the same as the picture box else you need to manage that by resizing for example.
https://stackoverflow.com/questions/1922040/how-to-resize-an-image-c-sharp
