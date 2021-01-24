    public class ApplicationDbContexto : DbContext 
    {
        public CategoriaContexto(DbContextOptions<CategoriaContexto> options) : base(options)
        {
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
