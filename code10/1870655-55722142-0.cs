    public async Task<IHttpActionResult> PostCUSTOMER(CUSTOMERDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (dto != null)
            {
                CUSTOMER cust = new CUSTOMER();
                //write code to assign dto to cust object
                db.CUSTOMERs.Add(cust);
            }
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CUSTOMERExists(dto.CUSTOMER_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("DefaultApi", new { id = dto.CUSTOMER_ID }, dto);
        }
     public class CUSTOMERDTO
    {
        public decimal CUSTOMER_ID { `enter code here`get; set; }
        public string CUSTOMER_USERNAME { get; set; }
        public string CUSTOMER_PASSWORD { get; set; }
        public string CUSTOMER_NAME { get; set; }
        public string CUSTOMER_EMAIL { get; set; }
    }
