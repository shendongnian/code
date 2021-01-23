        public DepartmentMap()
        {
          
            Schema("organizationstructure");
            KeyColumn("PartyId");
           
            Map(p => p.DepartmentType)
                .Not.Nullable()
                .CustomSqlType("tinyint")
                .CustomType<DepartmentType>()
                .Length(1);
            HasManyToMany(p => p.DepartmentGroup)
                .Table("DepartmentGroupToDepartment")
                .Schema("formation");
       }
    }
