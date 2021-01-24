       // The form that you want to copy the item from
    public class form1
    {
    // This is the event that will be raised when you click the button.
    public event EventHandler<ShareSelectedItemEventArgs> ShareSelectedItemData;
       
    //This is where you click your button in form1
    private void Ajuoter_ce_Produit_Click(object sender, EventArgs args)
    {
     if(ShareSelectedItemData != null)
         ShareSelectedItemData(this, new ShareSelectedItemEventArgs() { ProductItem = (ProductItem)datagrid1.SelectedItem});
       }
    }
    // The form to send the data to
    public class form2
    {
        public form2()
        {
            // Listen for the event in form1 here
            form1.ShareSelectedItemData += (object sender, ShareSelectedItemEventArgs args) => ListenForItem(sender, args);
        }
        private void ListenForItem(object sender, ShareSelectedItemEventArgs args)
        {
            //handle the display of your item here.
            // The selected item can be accessed through args.ProductItem
        }
    }
    public class ShareSelectedItemEventArgs : EventArgs
    {
        // This is the product item in your api or whatever you may have called it
        // it contains properties of price, name etc.
        public Product ProductItem { get; set; }
        public ShareSelectedItemEventArgs() : base()
        {
        }
    }
