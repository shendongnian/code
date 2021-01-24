        /// <summary>
        /// This method validates and submits your report for processing 
        /// </summary>    
        /// <param name="ReportName">This is the name of your report</param>
        /// <param name="ReportTotalUSD">This is the total amount in USD</param>
        /// <param name="ReportDate">This is the date you incurred expenses</param>
        [AllowAnonymous]
        [HttpPost]
        [ResponseType(typeof(List<int>))]
        public IHttpActionResult SubmitReport(string ReportName, decimal ReportTotalUSD, DateTime ReportDate)
