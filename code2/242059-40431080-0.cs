    public class YourDataItem
    {
        // put all of your data here. This is just stubbed here as an example
        public int Id { get; set; }
        public String Description { get; set; }
    }
    private void DeleteBtn_Down(Object sender, MouseEventArgs e)
    {
        var item = (YourDataItem)bindingSource1.Current;
        var dr = DialogResult.None;
        if (0 < item.Id)
        {
            var ask = String.Format("Delete Item [{0}]?", item.Description);
            dr = MessageBox.Show(ask, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        if (dr == DialogResult.Yes)
        {
            try
            {
                bindingSource1.EndEdit();
                _datamodel.YourDataItems.DeleteOnSubmit(item);
                _datamodel.SubmitChanges();
                _datamodel.ClearCache();
                bindingSource1.SetPosition<YourDataItem>(x => x.Id == 0);
            } catch (Exception err)
            {
                MessageBox.Show("Database changes failed to complete.", String.Format("Delete {0}", err.GetType()), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        } else
        {
            bindingSource1.CancelEdit();
        }
    }
