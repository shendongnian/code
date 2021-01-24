    [HttpGet]
    public virtual ActionResult PdfInvoice(int customerOrderselectedId)
    {
        var customerOrder = _customerOrderService.GetCustomerOrderById(customerOrderselectedId);
        var customerOrders = new List<DD_CustomerOrder>();
        customerOrders.Add(customerOrder);
        byte[] bytes;
        using (var stream = new MemoryStream())
        {
            _customerOrderPdfService.PrintInvoicePdf(stream, customerOrders);
            bytes = stream.ToArray();
        }
        // use 2 parameters
        return File(bytes, MimeTypes.ApplicationPdf);
    }
