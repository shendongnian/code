        internal class Cart : IEnumerable<string>
        {
            public List<string> Items { get; set; }
            public Cart()
            {
                Items = new List<string>();
            }
            public IEnumerator<string> GetEnumerator()
            {
                return Items.GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Cart _cart = new Cart();
            //_cart.Items.Add("bread");
            //_cart.Items.Add("apples");
            //_cart.Items.Add("eggs");
            lvShoppingCart.DataSource = _cart;
            // Make sure the 'InsertItemTemplate' is hidden from view when items are added to the cart.
            lvShoppingCart.InsertItemPosition = _cart.Items.Count == 0 ? InsertItemPosition.LastItem : InsertItemPosition.None;
            lvShoppingCart.DataBind();
            Label _lblCartTotal = lvShoppingCart.FindControl("lblCartTotal") as Label;
            if (_lblCartTotal != null)
            {
                _lblCartTotal.Text = string.Format("<strong>Total: </strong> {0}", _cart.Items.Count);
            }
        }
