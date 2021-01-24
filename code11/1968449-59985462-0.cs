        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }
>    
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        // app.UseCookiePolicy();
