    [HttpGet]
    [Route("verifydocument/{loadId:long}")]
    public IHttpActionResult VerifyDocument(long loadId)
        {
            try
            {
                var loan= _loanService.FindLoanById(loadId);
                if (loan.LoanStatus!=null && loan.LoanStatus.Equals(LoanStatus.DocumentUploaded)
                //Do logic for the verifyDocument and update the LoanStatus to DocumentVerified
                {  
                   return Ok(loanUpdated);
                }
                return Forbid();
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }
