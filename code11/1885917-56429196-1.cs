            Model = RuntimeTypeModel.Create();
            Model.Add(typeof(FooA), false)
                .AddSubType(201, typeof(FooB))
                //.AddSubType(202, typeof(FooA1))
                .Add(1, "A")
                .Add(2, "B");
            Model[typeof(FooB)]
                //.AddSubType(201, typeof(FooC))
                .Add(1, "C");
            Model[typeof(FooC)]
                .AddSubType(201, typeof(FooD));                
            Model[typeof(FooD)]
                .Add(1, "D");
            Model.Add(typeof(FooAFake), false)
                .AddSubType(201, typeof(FooBFake))
                .AddSubType(202, typeof(FooA1))
                .Add(1, "A")
                .Add(2, "B");
            Model[typeof(FooBFake)]
                .AddSubType(201, typeof(FooC))
                .Add(1, "C");
