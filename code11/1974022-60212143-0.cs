    [HttpPost]
    public EmptyResult OnPostTest()
            {
                //Ensure the Data has been Correctly Entered into the form.
                if (!ModelState.IsValid)
                {
                    error = "The Data was not In the correct form,Please try again.";
                    BfvEncryption bfv = new BfvEncryption();
                    return new EmptyResult();
    
                }
                error = "Is this working";
    		 return new EmptyResult();
            }
