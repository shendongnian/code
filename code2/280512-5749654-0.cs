     protected void Page_Load(object sender, EventArgs e)
     {
         if (!IsPostBack)
         {
             StringBuilder sbParams = new StringBuilder();
             TotalQty += basketItem.Quantity;
             Sku = variant.Sku;
             sbParams.Append(string.Format("?sku={0}&Qty={1}",
                 Sku.Substring(0,4),TotalQty));
             popup = string.Format("window.open('http://somesite.ocm/cal.asp{0}', 
                 'Reservation Calendar','width=265,height=465')", 
                 sbParams.ToString());        
             btnCalendar.OnClientClick = popup;
         }
     }
