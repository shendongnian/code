    public partial class MTMainForm : Form, IMTMainForm
    {
      public BindingSource bSRCOrders
      {
        get => (BindingSource)dGVOrders.DataSource;
        set => SetBindingSRC(dGVOrders, value); //dGVOrders = DataGridView
      }
    
      private void SetBindingSRC(DataGridView dgv, BindingSource bs)
      {
        //if (dgv.DataBindings.Equals(bs))   --> Commented this
        //  return;                          --> Commented this
    
        if (!InvokeRequired)
        {
          dgv.DataSource = bs;
          ((BindingSource)dgv.DataSource).ResetBindings(false); // Add this to refresh DGV
          return;
        }
    
        this.Invoke(new Action(() =>
        {
          dgv.DataSource = bs;
          ((BindingSource)dgv.DataSource).ResetBindings(false); // Add this to refresh DGV
        }));
      }
    }
