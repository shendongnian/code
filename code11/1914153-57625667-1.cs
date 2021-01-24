    static void Main(string[] args) {
        var kernel = new StandardKernel();
        kernel.Load(new DependencyModule());
        IDrawPresenter prisenter = kernel.Get<IDrawPresenter>();
        prisenter.Show();
        Console.ReadLine();
    }
