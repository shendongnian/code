        protected void Page_Load(object sender, EventArgs e)
        {
            if(this.IsPostBack)
            {
                PaymentInformation newPayInfo = new PaymentInformation();
                newPayInfo.MerchantID = merchantId.Text; // to get text
                /* Validation of input goes here ... */
                // Then send data.
            }
        }
