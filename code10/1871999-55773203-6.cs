    public class ApplicationDbContexto : DbContext 
    {
        public ApplicationDbContexto(DbContextOptions<ApplicationDbContexto> options) : base(options)
        {
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
