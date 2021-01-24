C#
for (int i = 0; i < 3; i++)
{
    resultMessage.Text = "Hello";
    if (newStudent[i] != null)
    {
        string fullName = newStudent[counter].Name();
        if (fullName.ToUpper() == newStudent[i].Name().ToUpper())
        {
            resultMessage.Text = "Name is already in the system.";
            return;
        }
    }            
}
if (counter > 2)
{
    resultMessage.Text = "Array is full.";
    return;
}
else
{
    newStudent[counter] = new Student(StudentID.Text, FirstName.Text, MiddleInitial.Text, LastName.Text, HouseNumber.Text, Street.Text, CityCounty.Text, Country.Text,
    State.Text, ZipCode.Text, DOB.Text);
    resultMessage.Text = "Age: " + newStudent[counter].Age;
}
counter++;
