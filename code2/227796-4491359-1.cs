    public class ClassOneMappingOverride : IAutoMappingOverride<ClassOne>
        {
            public void Override(AutoMapping<ClassOne> mapping)
            {
                mapping.HasManyToMany(x => x.Tags).AsArray(x => x.Id).ParentKeyColumn("classOneId")
                    .ChildKeyColumn("classTwoId")
                    .Table("ClassOneLinkClassTwo")
                    .Cascade.SaveUpdate();
            }
        }
