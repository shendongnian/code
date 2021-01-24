     var list=from msi in db.MainSaleInvoiceTbls
              join dsi in db.DetialSaleInvoiceTbls on msi.Id equals dsi.MainSaleInvoiceId
              join ca in db.CustomerAccounts on msi.CustomerId equals ca.Id
              join cg in db.MiscLists on ca.CustomerGroupId equals cg.Id into a
              where msi.IsActive == true && msi.CompanyId == UniversalInfo.UserCompany.Id 
              && msi.MainSaleInvoiceDataType == MainSaleInvoiceType.SOInvoice
              from cg in a.DefaultIfEmpty()
              select new
              {mainSaleInvoice.Date, 
               mainSaleInvoice.FinancialVoucher,mainSaleInvoice.AccountCode,
               mainSaleInvoice.CustomerName,mainSaleInvoice.Name,
               mainSaleInvoice.SaleOrderPrefix, mainSaleInvoice.SaleOrderNumber,
               mainSaleInvoice.SalesId, }).sum(x=>x. (mainSaleInvoice.Quantity * 
               mainSaleInvoice.UnitPrice)).groupby msi new 
              {msi.Date,msi.FinancialVoucher,msi.SaleOrderPrefix,msi.SaleOrderNumber,
               msi.SalesId};
              Date = mainSaleInvoice.Date;
              Voucher = mainSaleInvoice.FinancialVoucher;
              InvoiceAccount = mainSaleInvoice.AccountCode;
              CustomerName = mainSaleInvoice.CustomerName;
              CustomerGroup = mainSaleInvoice.Name;
              Invoice = mainSaleInvoice.SaleOrderPrefix + 
              mainSaleInvoice.SaleOrderNumber;
              PurchaseOrder = mainSaleInvoice.SalesId;
              SalesTax = "";
              InvoiceAmount =list;
