    public class ApplicationDbContext {
        protected override void OnModelCreating(ModelBuilder builder) {
            // your other code here
            builder.Entity<Funcionario>(entity => {
				entity.HasOne(e => e.Empresa)
					.WithMany(e => e.Funcionarios);
			});
            // rest of your code
        }
    }
