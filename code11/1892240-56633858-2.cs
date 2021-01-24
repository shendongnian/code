    [EntryPoint]
    static void Multiply(ResidentArrayGeneric<Complex> a, ResidentArrayGeneric<Complex> b, FloatResidentArray d, int len)
    {
    
    }
    
    static void Main(string[] args)
    {
        int numelements = 12;
        var a = new ResidentArrayGeneric<Complex>(numelements);
        var b = new ResidentArrayGeneric<Complex>(numelements);
        var d = new FloatResidentArray(numelements);
    
        // populate a and b
    
        a.RefreshDevice();
        b.RefreshDevice();
    
    
        HybRunner runner = HybRunner.Cuda();
        dynamic wrapped = runner.Wrap(new Program());
        runner.saveAssembly();
    
        // the following line gives a runtimeBinderException as detailed below
        wrapped.Multiply(a, b, d, numelements);
    
        d.RefreshHost();
    
        cuda.DeviceSynchronize();
    }
