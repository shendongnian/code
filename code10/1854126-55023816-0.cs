    using Ecommerce.Core;
    using Ecommerce.Core.Domain.Categorias;
    using Ecommerce.Core.Domain.Roles;
    using Ecommerce.Core.Domain.Usuarios;
    using Ecommerce.Data.ModelExtensions;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    
    namespace Ecommerce.Data
    {
        public class EcommerceContext : IdentityDbContext<Usuario, Role, int>
        {
            public DbSet<Categoria> Categoria { get; set; }
            public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options) { }
    
            protected override void OnModelCreating(ModelBuilder builder)
            {
                //builder.AddEntityConfigurationsFromAssembly(GetType().Assembly);
                builder.Entity<Categoria>(c =>
                {
                    c.ToTable("Categoria");
                    c.HasKey(i => i.Id);
                    c.Property(i => i.Nome);
                    c.Property(i => i.dataCadastro);
                });
				
				base.OnModelCreating(builder);
            }
        }
    }
