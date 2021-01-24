    [HttpPost("Data/{Customer}")]
    public async Task<IActionResult> GetCustomerDataAsync(string CustomerID, [FromBody] QueryParameters[] parameters, CancellationToken ct) {
        try {
            DataSet data = await GetCustomerData(CustomerID, parameters, ct);
            return Ok(data);
        } catch(Exception ex) {
            //handle error (Logging?) and return appropriate response
            return StatusCode(500, new { error = "friendly_message_here" });
        }
    }
