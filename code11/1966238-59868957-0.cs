    [Test]
    public void TestCopyOver()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ClassA, ClassB>()
                .ForMember(x => x.MyName, x => x.MapFrom(y => y.Name))
                .ForMember(x => x.MyOtherName, x => x.MapFrom(y => y.OtherName));
            cfg.CreateMap<ClassB, ClassA>()
                .ForMember(x => x.Name, x => x.MapFrom(y => y.MyName))
                .ForMember(x => x.OtherName, x => x.MapFrom(y => y.MyOtherName));
        });
        var mapper = config.CreateMapper();
        ClassA newA = new ClassA { Name = "Fred", OtherName = "Astaire" };
        ClassA altReferenceA = newA;
        Assert.AreSame(newA, altReferenceA, "References don't match.");
        var cloneB = mapper.Map<ClassB>(newA);
        cloneB.MyOtherName = "Rogers";
        newA = mapper.Map<ClassA>(cloneB);
        Assert.AreEqual("Rogers", newA.OtherName);
        Assert.AreEqual("Astaire", altReferenceA.OtherName); // original object not updated.
        Assert.AreNotSame(newA, altReferenceA); // now point to 2 different objects
        //Reset...
        newA = new ClassA { Name = "Fred", OtherName = "Astaire" };
        altReferenceA = newA;
        Assert.AreSame(newA, altReferenceA, "References don't match.");
        cloneB = mapper.Map<ClassB>(newA);
        cloneB.MyOtherName = "Rogers";
        mapper.Map(cloneB, newA);
        Assert.AreEqual("Rogers", newA.OtherName);
        Assert.AreEqual("Rogers", altReferenceA.OtherName); // Original object updated.
        Assert.AreSame(newA, altReferenceA); // Still point to same reference.
    }
