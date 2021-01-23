    public partial class MessageBoxForm : Form
    {
        ...
        public void LoadListView(ListViewItemCollection items)
        {
            orderListView.Clear();
            orderListView.AddRange(items);
        }
    }
    ....
    private void customerInformationToolStripMenuItem_Click(object sender, EventArgs e)    
    {    
        if (Customers.SelectedItems.Count != 0)    
        {    
            var myformmessagedialog = new MessageBoxForm    
            {    
                name = Customers.SelectedItems[0].SubItems[0].Text,    
                address = Customers.SelectedItems[0].SubItems[3].Text,    
                telephone = Customers.SelectedItems[0].SubItems[4].Text,    
            };
            myformmessagedialog.LoadListView(Customers.Items);
            myformmessagedialog.ShowDialog();    
        }    
    } 
