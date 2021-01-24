    namespace N1
    {
        struct A {};
    }
    
    namespace N2
    {
        using namespace N1;
        struct B : A
        {
        };
    }
