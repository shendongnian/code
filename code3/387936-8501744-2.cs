    class FinalOrder : IDisposible
    {
        ...
    }
    private void OrderLoad(object sender, EventArgs e)
    {
        using (var fo = new FinalOrder(...))
        {
            dgvOrder.DataSource = fo.FetchOrders();
        }
    }
