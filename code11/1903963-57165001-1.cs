    @if (Model != null)
    {
        foreach (var bill in Model)
        {
            <h1 class="separator"> شماره فاکتور  : @bill.InvoiceNumber</h1>
            if (bill.Tbl_Product.Product_IsDownload == false)
            {
                ....
            }
        }
    }
