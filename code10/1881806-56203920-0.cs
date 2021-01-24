    public partial class GatewaysImpressionsAndConversions
    {
      
        public string DOMAIN { get; set; }
        public int TOTAL_IMPRESSIONS { get; set; }
        public int UNIQUE_IMPRESSIONS { get; set; }
        public int CONVERSIONS { get; set; }
        public string DATE { get; set; }
    }
**created the Stored procedure too**
and then all i had to do on the controller was:
 var result = _context.GatewaysImpressionsAndConversions.FromSql("GetGatewaysImpressionsAndConversionsByDay '2019.05.16'");
            return View("Statistics", await result.ToListAsync());
and in my view at the top: 
