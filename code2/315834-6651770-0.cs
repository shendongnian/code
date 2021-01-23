    Customer[] getCustomers(Customer customerFilter) {
        Query q; // = new query on customer table
        if(customerFilter.isSetCustomerID()) {
            // add where clause to the query: 
            //     Customer.CUSTOMER_ID = customerFilter.getCustomerID()
        }
        // for each field
    }
    Customer[] getCustomers(Customer[] customerFilters) {
        Query q; // = new query on customer table
        // add where clause to the query for each field: 
            //    Customer.CUSTOMER_ID IN 
            //       [customerFilter : customerFilters].getCustomerID()
    }
    
