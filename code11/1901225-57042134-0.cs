public class BLLBaseClass
    {
        private IHttpContextAccessor httpContextAccessor;
        public BLLBaseClass(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public int UserId
        {
            get
            {
                var value = httpContextAccessor.HttpContext.User?.Claims?.First(c => c.Type == "UserId").Value;
                if (Int32.TryParse(value, out int userId))
                {
                    return userId;
                }
                return 0;
            }
        }
    }
Inherit that class and you can access directly userid
 public class GeneralBLL : BLLBaseClass
    {
        private readonly GeneralDAL _generalDal;
        public GeneralBLL(GeneralDAL generalDal, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _generalDal = generalDal;
        }
        public List<Department> GetDepartments()
        {
            var userId = UserId;
            try
            {
                return _generalDal.GetDepartments();
            }
            catch (Exception)
            {
                throw new Exception("unable to get departments.");
            }
        }
    }
