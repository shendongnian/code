c#
class Motor
{
    public int MotorId { get; set; }
    public string MotorType { get; set; }
    public override string ToString() // Important to override. This will be used to show the text in the combobox
    {
        return this.MotorType;
    }
}
And this is how you add `Motors` and read the SelectedItem:
// This is your Array which you got from your DB
Motor[] motors = new Motor[]
{
    new Motor() { MotorId = 1, MotorType = "Audi" },
    new Motor() { MotorId = 2, MotorType = "Ferrari" },
};
// We clear old items and add the motors:
this.comboBox1.Items.Clear();
this.comboBox1.Items.AddRange(motors);
// Select something for demonstration
this.comboBox1.SelectedIndex = 1;
// Read the selected item out of the combobox
Motor selectedMotor = this.comboBox1.SelectedItem as Motor; 
// Let's have a look what we got
MessageBox.Show(selectedMotor.MotorId + ": " + selectedMotor.MotorType);
