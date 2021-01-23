    using Namespace1;
    namespace MyApplication 
    {
        using Namespace2;
        ...
        db.Execute(); // Namespace2 Execute() will be called
    }
