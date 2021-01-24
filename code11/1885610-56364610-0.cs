     List<string> namelist = new List<string>();
     namelist.Add("Val");
     namelist.Add("Jeff");
     const string names = "{{#each name}} <h2> Hello, {{this}}</h2> {{/each}}";
     HtmlFormatCompiler compilers = new HtmlFormatCompiler();
     Generator generator = compilers.Compile(names);
     string result = generator.Render(new
     {
        name = namelist
     });
