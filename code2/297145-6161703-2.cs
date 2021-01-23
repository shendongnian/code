    public static void Main()
    {
        var module = new WeaponModule();
        var kernel = new StandardKernel(module);
        var weapon = kernel.Get<IWeapon>();
    }
