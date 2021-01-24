    <pre>
    app.UseSpa(spa =>
    {
        if (env.IsDevelopment())
            <strike>spa.Options.SourcePath = "ClientApp";</strike>
            spa.Options.SourcePath = "clientapp";
        <strike>else</strike>
        <strike>    spa.Options.SourcePath = "dist"</strike>
    
    </pre>
