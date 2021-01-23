    namespace MyManagedWrapper
    {
        public ref class YourClassDotNet
        {
        private:
            YourClass* ptr;
        public:
            YourClassDotNet()
            {
                ptr = new YourClass();
            }
            ~YourClassDotNet()
            {
                this->!YourClassDotNet();
            }
            !YourClassDotNet()
            {
                delete ptr;
                ptr = NULL;
            }
        }
    }
