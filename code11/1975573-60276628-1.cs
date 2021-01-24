    [HttpGet("Addap")]
    public IActionResult Addap(Customers customers)
    {
      List<Customers> cust = new List<Customers>();
      cust = _customerRepo.Addap(customers);
      if (cust != null)
      {
        return Ok(cust);
      }
      else
      {
        return (null);
      }
    }
