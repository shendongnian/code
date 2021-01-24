    public class LanguageRepository : BaseRepository, ILanguageRepository
    {
    
        private readonly IMemoryCache _memoryCache;
        private readonly IHttpContextAccessor _context;
    
    
        public LanguageRepository(AppDbContext _db, IHttpContextAccessor context
            , IMemoryCache memoryCache) 
            : base(_db)
        {
            _memoryCache = memoryCache;
            _context = context;
        }
    
    
        private string Url
        {
            get {
                return _context.HttpContext.Request.Path;
            }
        }
    
    
        /// <summary>
        /// Gets the language that the user is using.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        private string Language
        {
            get {
    
                var code = System.Threading.Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName.ToLower();
                if (new[] { "en", "de", "fr", "nl" }.Contains(code))
                    return code;
                else
                    return "en";
            }
        }
        public TextItem GetHtml(string key, string defaultIfNull)
        {
            var cashKey = string.Concat("tc_",Language ,"_", key);
            if (!_memoryCache.TryGetValue<TextItem>(cashKey, out TextItem result))
            {
                result = new TextItem(key: key, language: Language);
                using (var cmd = db.Database.GetDbConnection().CreateCommand())
                {
                    if (cmd.Connection.State != System.Data.ConnectionState.Open)
                        cmd.Connection.Open();
                    cmd.CommandText = "dbo.GetPageText";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Key", System.Data.SqlDbType.VarChar) { Value = key, Size = 150 });
                    cmd.Parameters.Add(new SqlParameter("@Language", System.Data.SqlDbType.VarChar) { Value = Language, Size = 3 });
                    cmd.Parameters.Add(new SqlParameter("@DefaultIfNull", System.Data.SqlDbType.NVarChar) { Value = defaultIfNull, Size = 4000 });
                    cmd.Parameters.Add(new SqlParameter("@Url", System.Data.SqlDbType.VarChar) { Value = Url, Size = 150 });
                    result.Text = cmd.ExecuteScalar().ToString();
                }
    
                _memoryCache.Set<TextItem>(cashKey, result, MemoryOptions);
            }
            return result;
        }
    
    
    
        public bool SetHtml(string key, string value)
        {
            var cashKey = string.Concat("tc_", Language, "_", key);
            TextItem result= new TextItem(key, Language) { Text= value };
            _memoryCache.Set<TextItem>(cashKey, result, MemoryOptions);
                            
            using (var cmd = db.Database.GetDbConnection().CreateCommand())
            {
                if (cmd.Connection.State != System.Data.ConnectionState.Open)
                    cmd.Connection.Open();
    
                cmd.CommandText = "dbo.SetPageText";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Key", System.Data.SqlDbType.VarChar) { Value = key, Size = 150 });
                cmd.Parameters.Add(new SqlParameter("@Language", System.Data.SqlDbType.VarChar) { Value = Language, Size = 3 });
                cmd.Parameters.Add(new SqlParameter("@Value", System.Data.SqlDbType.NVarChar) { Value = value, Size = 4000 });
                return cmd.ExecuteNonQuery()!=0;
            }           
                
        }
        public async Task<bool> SetHtmlAsync(string key, string value)
        {
            var cashKey = string.Concat("tc_", Language, "_", key);
            TextItem result= new TextItem(key, Language) { Text= value };
            _memoryCache.Remove(cashKey);
            _memoryCache.Set<TextItem>(cashKey, result, MemoryOptions);
                            
            using (var cmd = db.Database.GetDbConnection().CreateCommand())
            {
                if (cmd.Connection.State != System.Data.ConnectionState.Open)
                    cmd.Connection.Open();
    
                cmd.CommandText = "dbo.SetPageText";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Key", System.Data.SqlDbType.VarChar) { Value = key, Size = 150 });
                cmd.Parameters.Add(new SqlParameter("@Language", System.Data.SqlDbType.VarChar) { Value = Language, Size = 3 });
                cmd.Parameters.Add(new SqlParameter("@Value", System.Data.SqlDbType.NVarChar) { Value = value, Size = 4000 });
                return await cmd.ExecuteNonQueryAsync()!=0;
            }           
                
        }
    
        public async Task<bool> DeleteHtmlAsync(string key)
        {
            var cashKey = string.Concat("tc_", Language, "_", key);
            _memoryCache.Remove(cashKey);
    
            using (var cmd = db.Database.GetDbConnection().CreateCommand())
            {
                if (cmd.Connection.State != System.Data.ConnectionState.Open)
                    cmd.Connection.Open();
    
                cmd.CommandText = "dbo.DeletePageText";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Key", System.Data.SqlDbType.VarChar) { Value = key, Size = 150 });
                return await cmd.ExecuteNonQueryAsync() != 0;
            }
    
        }
    
        private MemoryCacheEntryOptions MemoryOptions=> new MemoryCacheEntryOptions() { Priority = CacheItemPriority.High, SlidingExpiration = DateTime.Now.AddHours(6) - DateTime.Now };
            
    }
