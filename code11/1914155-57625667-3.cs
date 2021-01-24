    static void Main(string[] args) {
        var kernel = new StandardKernel();
        kernel.Load(new DependencyModule());
        IDrawPresenter presenter= kernel.Get<IDrawPresenter>();
        presenter.Show();
        Console.ReadLine();
    }
