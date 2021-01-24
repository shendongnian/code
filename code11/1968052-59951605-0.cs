private void button1_Click(object sender, EventArgs e)
{
    // Create an instance of the Module class that the button click event can access.
    Module myModule = new Module();
    // Call the void function using the instance we just created.
    myModule.CreateInventorApplication();
}
