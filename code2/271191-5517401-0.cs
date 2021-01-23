            var jobUpdate = invoiceJobTable.Where(x => x.JobID == 10000).Single();
            jobUpdate.InvoiceRef = invoice.InvoiceID.ToString();
            invoiceJobTable.GetOriginalEntityState(jobUpdate);
            invoiceJobTable.Context.Refresh(RefreshMode.KeepCurrentValues, jobUpdate);
            invoiceJobTable.Context.SubmitChanges();
