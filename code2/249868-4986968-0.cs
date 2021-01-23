    private void ordersListBox_DoubleClick(object sender, EventArgs e)
    {
        if (ordersListBox.SelectedItem != null)
        {
            foreach (OrderInfo i in ordersList)
            {
                if (i.GetClientName().Equals(ordersListBox.ToString()))
                {
                    MessageBox.Show(i.GetClientName());
                    break;
                }
            }
        }
    }
