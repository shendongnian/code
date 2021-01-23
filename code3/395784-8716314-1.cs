    template <class T>
    class IDoSomething {
    public:
        virtual void DoSomething(T value) = 0;
    };
    template <class T>
    class Base : public virtual IDoSomething<T>
    {
    public:
        virtual void DoSomething(T value)
        {
            // Do something here
        }
    };
    class IDoubleDoSomething : public virtual IDoSomething<double>
    {
    };
    class Foo : public virtual Base<double>, public virtual IDoubleDoSomething
    {
    };
