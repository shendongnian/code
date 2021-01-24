    using (var order = new YourDBContext()) {
            if (!string.IsNullOrEmpty(await invoiceRepository.GetLastBillNo()))
                    {
                        billNo = long.Parse(await invoiceRepository.GetLastBillNo());
                        billNo = billNo + 1;
                        order.CustomOrderNumber = billNo.ToString();
                    }
                    else
                        order.CustomOrderNumber = (billNo + 1).ToString();
    ...rest of your code
        }
