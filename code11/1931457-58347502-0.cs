    public class MyViewModel : INotifyPropertyChanged
    {
        
        protected readonly IServiceScopeFactory _ServiceScopeFactory;
        public MyViewModel(IServiceScopeFactory serviceScopeFactory)
        {
            _ServiceScopeFactory = serviceScopeFactory;
        }
    
        public async Task<IEnumerable<Dto>> GetList(string s)
        {
            using (var scope = _ServiceScopeFactory.CreateScope())
            {
                var referenceContext = scope.ServiceProvider.GetService<MyContext>();    
                return await _myContext.Table1.where(....)....ToListAsync();
            }
        }
