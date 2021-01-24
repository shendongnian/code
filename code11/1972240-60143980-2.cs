    <pre>
    app.UseSpa(spa =>
    {
        if (env.IsDevelopment())
            spa.Options.SourcePath = "ClientApp";
        <strike>else</strike>
        <strike>    spa.Options.SourcePath = "dist"</strike>
    
    </pre>
