    partial class Startup {
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env
        ) {
            app.UsePathBase(new PathString("/MyApplication"));
            app.UseMvc();
        }
    }
