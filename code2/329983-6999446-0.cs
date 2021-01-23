    private void Fun()
    {
        // call C::PrintMe - part one
        PrintMe();
        // call B::PrintMe - part two
        base.PrintMe();
        // call A::PrintMe - part three
        MethodInfo mi = this.GetType().GetMethod("PrintMe").GetBaseDefinition();
        
        var dm = new DynamicMethod("dm", null, new[] { typeof(object) }, this.GetType());
        ILGenerator il = dm.GetILGenerator();
        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Call, mi);    // use call rather than callvirt
        il.Emit(OpCodes.Ret);
        var action = (Action<object>)dm.CreateDelegate(typeof(Action<object>));
        action(this);
    }
