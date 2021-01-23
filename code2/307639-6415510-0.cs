    internal class EmployeeMapping : EntityTypeConfiguration<Employee>
    {
        public EmployeeMapping()
        {
            HasKey(a => a.Id);
            Property(a => a.Id).HasColumnName("UserId");
            HasRequired<Department>(a => a.Department).WithMany()
                                                      .Map(a => a.MapKey("DepartmentId"));
        }
    }
    internal class RotaMapping : EntityTypeConfiguration<Rota>
    {
        public RotaMapping()
        {
            HasKey(a => a.Id);
            Property(a => a.Id).HasColumnName("RotaId");
            HasOptional<Employee>(a => a.Employee).WithMany()
                                                  .Map(a => a.MapKey("EmployeeId"));
            HasOptional<Department>(a => a.Department).WithMany()
                                                      .Map(a => a.MapKey("DepartmentId"));
        }
    }
