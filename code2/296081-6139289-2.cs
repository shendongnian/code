    public class UsuarioRepository : BaseRepository<IUsuario>,
        IUsuarioRepository
    {
        private DatabaseContext _databaseContext;
        
        public UsuarioRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        
        protected override DatabaseContext GetContext()
        {
            return _databaseContext;
        }
    }
