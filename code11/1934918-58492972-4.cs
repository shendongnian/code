    class Hello
    {
    public:
        Hello() : wrapper_("hello.dll", "namespace name") {}
        void HelloWorld()
        {
            wrapper_("Hello");
        }
    private:
        nativeAdapter::NativeProxy wrapper_;
    };
    }
