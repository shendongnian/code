    public void CreateMethod()
    {
        AppDomain currentDomain = AppDomain.CurrentDomain;
        AssemblyBuilder asmbuilder = this.GetAssemblyBuilder("MyAssembly");
        ModuleBuilder mbuilder = this.GetModule(asmbuilder);
        TypeBuilder tbuilder = this.GetTypeBuilder(mbuilder, "MyClass");
    
        Type[] tparams = { typeof(System.Int32), typeof(System.Int32) };
        MethodBuilder methodSum = this.GetMethod(tbuilder, "Sum", typeof(System.Single), 
                                                                     tparams);
        
        ILGenerator generator = methodSum.GetILGenerator();
    
        generator.DeclareLocal(typeof(System.Single));  
        generator.Emit(OpCodes.Ldarg_1);    
        generator.Emit(OpCodes.Ldarg_2);    
        generator.Emit(OpCodes.Add_Ovf);    
        generator.Emit(OpCodes.Conv_R4);    
        generator.Emit(OpCodes.Stloc_0);    
              
        generator.Emit(OpCodes.Ldloc_0);    
        generator.Emit(OpCodes.Ret);        
    }
