    public static explicit operator InvoiceWithEntryInfo(ServiceInfo item){
         return new InvoiceWithEntryInfo {
                 IdIWEI = item.ID,
                 AmountIWEI = item.Amount,
                 DateIWEI = item.Date};
     }
