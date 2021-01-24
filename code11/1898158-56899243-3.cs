    public void ConfigureServices(IServiceCollection services)
    {
       services.AddHttpClient<IStudentClient, StudentClient>();
       services.AddTransient<IStudentProvider, HttpStudentProvider>();
    }
