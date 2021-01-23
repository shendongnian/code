        container.Add("fake.Test", fake.Test);
        removed = container.Remove("fake.Test");
        Debug.Assert(removed);   
        container.Add("anon", p => { fake.Test(p); counter++; });
        removed = container.Remove("anon"); // works!
        Debug.Assert(removed);   
