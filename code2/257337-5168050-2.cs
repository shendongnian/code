    public OwnerMapping()
        {
            this.Table("Owners");
            Id(x => x.Id).GeneratedBy.Native();
            HasMany(x => x.Animals.AsBag.Cascade.AllDeleteOrphan()
                .Inverse().LazyLoad()
                .Access.CamelCaseField(Prefix.Underscore);
        }
    }
