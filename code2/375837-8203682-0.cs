    public static Func<DatabaseEntities, string, IQueryable<Employee>> GetAllByName =
                  CompiledQuery.Compile<DatabaseEntities, string, IQueryable<Employee>
                  ((context, name) => context.Employees
                         .Include("Email")
                         .Where(e => e.LastName == name));
