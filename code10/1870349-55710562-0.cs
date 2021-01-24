    public class Form2 : Form
    {
        // start creating the delegate type
        public delegate void OnItemSelected(string itemName);
        // declare the public event that this form will raise
        public event OnItemSelected ItemSelected;
        protected void cmdItemUse_Click(object sender, EventArgs e)
        {
             // When the user clicks to select an item....
             string itemName = GetItemSelectedFromList();
             // Check if someone is interested in this item selection
             if(ItemSelected != null)
                 ItemSelected.Invoke(itemName);
        }
    }
