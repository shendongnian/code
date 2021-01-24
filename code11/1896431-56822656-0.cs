    private static void AddDynamicTables(Configuration cfg)
        {
            var clients = new List<string>() { "First", "Second" };
            foreach (var client in clients)
            {
                var mapper = new ModelMapper();
                var map = new ClassMapping<Rule>();
                map.EntityName("tbl_" + client + "_rules");
                map.Property(x=>x.RuleId);
                map.Table("tbl_" + client + "_rules");
                mapper.AddMapping(map);
                var mappings = mapper.CompileMappingForAllExplicitlyAddedEntities();
                cfg.AddMapping(mappings);
            }
        }
