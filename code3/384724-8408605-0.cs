        class DynamicDictionaryFactory : DynamicObject
        {
            public override bool TryInvokeMember(
                InvokeMemberBinder binder, object[] args, out object result)
            {
                if (binder.Name == "Create")
                {
                    // use binder.CallInfo.ArgumentNames and args
                    // to create the dynamic dictionary
                    result = …;
                    return true;
                }
                return base.TryInvokeMember(binder, args, out result);
            }
        }
        …
        dynamic factory = new DynamicDictionaryFactory();
        dynamic dict = factory.Create(Id: 42);
