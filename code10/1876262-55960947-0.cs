c#
string path = Path.Combine(Directory.GetCurrentDirectory(), "App_Data");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection").Replace("[DataDirectory]", path)));
            services.AddDefaultIdentity<IdentityUser>()
**appsettings.json**
"DefaultConnection": "Server=(localdb)\\mssqllocaldb;AttachDbFilename=[DataDirectory]\\aspnet-MatrixCalculatorApp-db.mdf;Trusted_Connection=True;MultipleActiveResultSets=true"
I replaced |DataDirectory| with **[DataDirectory]** to avoid program confusion with the substitution string. But if someone has a better explanation than me, it would be nice to do it.
