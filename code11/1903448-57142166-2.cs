    [HttpGet("GetCustomerDetails/${id}")]
    public async Task<CustomerListingDto> GetCustomerDetails(long id)
    {
    
       CustomerServiceModel customers = await
       _accountService.GetCustomerDetailsByCustomerId(id);
    
       return _mapper.Map<CustomerListingDto>(customers);
    }
