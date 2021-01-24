        public class HomeController : Controller
        {
            private readonly ApplicationDbContext _context;       
            public HomeController(ApplicationDbContext context)
            {
                _context = context;
            }        
            public async Task<IActionResult> Index()
            {
                using (var connection = _context.Database.GetDbConnection())
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();
                    cmd.CommandText = "[dbo].[DUES_AUTO_PAYMENT]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    DbParameter pPaymentAmount = cmd.CreateParameter();
                    pPaymentAmount.ParameterName = "@Name";
                    pPaymentAmount.DbType = DbType.String;
                    pPaymentAmount.Direction = ParameterDirection.Input;
                    pPaymentAmount.Value = "Tom";            
                    cmd.Parameters.Add(pPaymentAmount);
                    try
                    {
                        var x = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        return Ok(ex.Message);
                    }
                }            
            }       
        }
