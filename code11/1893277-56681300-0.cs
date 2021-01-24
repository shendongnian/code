    [HttpPost("{bId}/employees/")]
    public async Task<IActionResult> PostEmployee([FromRoute] int bId,[FromBody] Employee emp)
    {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
    
                _context.Companies.Where(i=>i.branchId==bId).Employees.Add(emp);
                await _context.SaveChangesAsync();
    
                return CreatedAtAction("GetEmployee", new { id = emp.employeeId }, emp);
    }
