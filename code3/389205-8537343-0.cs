    public delegate Guid GetProperty<T>(T obj);
            public delegate void AttachChildren<TParent, TChild>(TParent parent, IEnumerable<TChild> children);
            private void AttachChildrenToParent<TParent, TChild>(IEnumerable<TParent> parents, IEnumerable<TChild> children, GetProperty<TParent> getID, 
                GetProperty<TChild> getParentID, AttachChildren<TParent, TChild> attachObjects)
            {
                parents.GroupJoin(
               children,
               p => getID(p),
               c => getParentID(c),
               (p, cn) => new { Parent = p, Children = cn })
               .ToList().ForEach(x => attachObjects(x.Parent, x.Children)); 
    
            }
    
            private class Class1 { public Guid ID { get; set; } public IEnumerable<Class2> Children { get; set; } }
            private class Class2 { public Guid ID { get; set; } public Guid ParentID { get; set; } }
            private void test()
            {
                IEnumerable<Class1> lst1 = new List<Class1>();
                IEnumerable<Class2> lst2 = new List<Class2>();
                AttachChildrenToParent<Class1, Class2>(lst1, lst2, x => x.ID, x => x.ParentID, (x, y) => x.Children = y);
            }
