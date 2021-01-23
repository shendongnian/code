    class MyDynamicObject : DynamicObject
    {
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            Console.WriteLine(binder.Name);
             //simply prints the name, you can raise an event here or something else
            return base.TryGetMember(binder, out result);
        }
    }
