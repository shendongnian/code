cs
DirectoryObjectPickerDialog picker = new DirectoryObjectPickerDialog()
{
    AllowedObjectTypes = ObjectTypes.Computers,
    DefaultObjectTypes = ObjectTypes.Computers,
    AllowedLocations = Locations.All,
    DefaultLocations = Locations.JoinedDomain,
    MultiSelect = true,
    ShowAdvancedView = true
};
if (picker.ShowDialog() == DialogResult.OK)
{
    foreach (var sel in picker.SelectedObjects)
    {
        Console.WriteLine(sel.Name);
    }
}
