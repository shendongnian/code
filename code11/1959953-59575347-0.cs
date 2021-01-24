public class Form1
{
List<Control> createdList = new List<Control>(); // class field
void combobox_SelectedIndexChanged()
{
            // removing controls were created before
            foreach (var created in createdList)
            {
              this.Controls.Remove(created);
              created.Dispose();
            }
            createdList.Clear(); // all created controls from previous index changed should be removed here
            // add each control you are creating to the createList additionally
            inputField1 = new TextBox[fieldCounter];
            for (int i = 0; i < fieldCounter; i++)
            {
                btnAddField0.Visible = false;
                inputField = new TextBox();
                createdList.Add(inputField); //store reference
/// skipping init code
                this.Controls.Add(inputField1[i]);
                positionController[comboboxNo, 0] += 81;
            }
}
}
another option is to add panel on the form as a placeholder for all controls are being created. You have to change `this.Controls.Add(inputField1[i]);` to the `panelCreated.Controls.Add(inputField1[i]);` 
Then you can grab all controls from the panel and remove them without name search like below
foreach (Control created in panelCreated.Controls)
  created.Dispose();
panelCreated.Controls.Clear();
