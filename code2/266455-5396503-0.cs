    public Customer GetCustomerWithInvoices(int id) {
      var customer = customerRepository.Get(id);
      var invoiceList = invoiceRepository.GetAllInvoicesFor(id);
      return new Customer {
        Customer = customer,
        Invoices = invoiceList
      };
    }
