    public partial class CustomerManagementView : Form, ICustomerManagementView
    {
        public CustomerManagementView()
        {
            this.InitializeComponents();
        }
        public void InitializeCustomers(ICustomer[] customers)
        {
            // Populate the tree view with customer details
        }
        public void DisplayCustomer(ICustomer customer)
        {
            // Display the customer...
        }
        // Event handler that responds to node selection
        private void CustomerTreeViewAfterSelect(object sender, TreeViewEventArgs e)
        {
            var customer = e.Node.Tag as ICustomer;
            if(customer != null)
            {
                this.OnSelectedCustomerChanged(new EventArgs<ICustomer>(customer));
            }
        }
        // Protected method so that we can raise our event
        protected virtual void OnSelectedCustomerChanged(EventArgs<ICustomer> args)
        {
            var eventHandler = this.SelectedCustomerChanged;
            if(eventHandler != null)
            {
                eventHandler.Invoke(this, args);
            }
        }
        // Our view will raise an event each time the selected customer changes
        public event EventHandler<EventArgs<ICustomer>> SelectedCustomerChanged;
    }
