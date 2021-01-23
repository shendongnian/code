    using System.Collections;
    using System.Windows.Forms;
    
    namespace FilterWinFormsTreeview
    {
      // The basic Customer class.
      public class Customer : System.Object
      {
        private string custName = "";
        protected ArrayList custOrders = new ArrayList();
    
        public Customer(string customername) {
          this.custName = customername;
        }
    
        public string CustomerName {
          get { return this.custName; }
          set { this.custName = value; }
        }
    
        public ArrayList CustomerOrders {
          get { return this.custOrders; }
        }
      }
    
      // End Customer class 
    
      // The basic customer Order class.
      public class Order : System.Object
      {
        private string ordID = "";
    
        public Order(string orderid) {
          this.ordID = orderid;
        }
    
        public string OrderID {
          get { return this.ordID; }
          set { this.ordID = value; }
        }
      }
    
      // End Order class
    
      public static class TreeViewHelper
      {
        // Create a new ArrayList to hold the Customer objects.
        private static ArrayList customerArray = new ArrayList();
    
        public static void FilterTreeView(TreeView treeView1, string orderText) {
          if (string.IsNullOrEmpty(orderText)) {
            FillMyTreeView(treeView1);
          } else {
            // Display a wait cursor while the TreeNodes are being created.
            Cursor.Current = Cursors.WaitCursor;
    
            // Suppress repainting the TreeView until all the objects have been created.
            treeView1.BeginUpdate();
    
            foreach (TreeNode customerNode in treeView1.Nodes) {
              var customer = customerNode.Tag as Customer;
              if (customer != null) {
                customerNode.Nodes.Clear();
                // Add a child treenode for each Order object in the current Customer object.
                foreach (Order order in customer.CustomerOrders) {
                  if (order.OrderID.Contains(orderText)) {
                    var orderNode = new TreeNode(customer.CustomerName + "." + order.OrderID);
                    customerNode.Nodes.Add(orderNode);
                  }
                }
              }
            }
    
            // Reset the cursor to the default for all controls.
            Cursor.Current = Cursors.Default;
    
            // Begin repainting the TreeView.
            treeView1.EndUpdate();
          }
        }
    
        public static void FillMyTreeView(TreeView treeView1) {
          // Add customers to the ArrayList of Customer objects.
          if (customerArray.Count <= 0) {
            for (int x = 0; x < 1000; x++) {
              customerArray.Add(new Customer("Customer" + x.ToString()));
            }
    
            // Add orders to each Customer object in the ArrayList.
            foreach (Customer customer1 in customerArray) {
              for (int y = 0; y < 15; y++) {
                customer1.CustomerOrders.Add(new Order("Order" + y.ToString()));
              }
            }
          }
    
          // Display a wait cursor while the TreeNodes are being created.
          Cursor.Current = Cursors.WaitCursor;
    
          // Suppress repainting the TreeView until all the objects have been created.
          treeView1.BeginUpdate();
    
          // Clear the TreeView each time the method is called.
          treeView1.Nodes.Clear();
    
          // Add a root TreeNode for each Customer object in the ArrayList.
          foreach (Customer customer2 in customerArray) {
            var customerNode = new TreeNode(customer2.CustomerName);
            customerNode.Tag = customer2;
            treeView1.Nodes.Add(customerNode);
    
            // Add a child treenode for each Order object in the current Customer object.
            foreach (Order order1 in customer2.CustomerOrders) {
              var orderNode = new TreeNode(customer2.CustomerName + "." + order1.OrderID);
              customerNode.Nodes.Add(orderNode);
            }
          }
    
          // Reset the cursor to the default for all controls.
          Cursor.Current = Cursors.Default;
    
          // Begin repainting the TreeView.
          treeView1.EndUpdate();
        }
      }
    }
