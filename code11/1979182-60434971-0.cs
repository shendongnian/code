 csharp
for (int i = 0; i < 3; ++i)
{
    using(var program = serviceProvider.GetService<Program>()){
        program.Go();
    }
}
you should acheive the same result.
