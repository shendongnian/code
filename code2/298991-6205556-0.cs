        class FooRelation{
            public Foo Parent {get; set;}
            public Foo Child  {get; set;}
        }
        static IEnumerable<FooRelation> GetChildren(Bar source, Foo parent){
            var children = source.Foos.Where(c => c.Definition.Parent == parent.Definition);
            if(children.Any())
                return children.Select(c => new FooRelation{Parent = parent, Child = c});
            return new FooRelation[]{new FooRelation{Parent = parent}};
        }
