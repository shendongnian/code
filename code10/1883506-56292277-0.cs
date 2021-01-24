using System.Linq.Dynamic;
namespace JDE_Scanner_Desktop.Static
{
    static class Extensions
    {
        public static int GetSelectedValue<T>(this ComboBox combobox)
        {
            return (int)typeof(T).GetProperty(combobox.ValueMember).GetValue(combobox.SelectedItem);
        }
        public static void SetSelectedValue<T>(this ComboBox combobox, int? selectedValue)
        {
            if(selectedValue != null)
            {
                combobox.SelectedItem = combobox.Items.Cast<T>().Where(combobox.ValueMember + $"={selectedValue}").FirstOrDefault();
            }
        }
    }
}
Then I'm setting item to be selected with ```cmbPart.SetSelectedValue<Part>(this.PartId);``` and I'm getting selcted item's SelectedValue with ```cmbPart.GetSelectedValue<Part>(); ```.
Of course I'm open for other solutions!
