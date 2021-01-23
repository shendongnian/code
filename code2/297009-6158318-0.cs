    generic<typename T>
    public ref struct Id : System::IComparable<Id<T>^>
    {
    public:
        virtual int CompareTo(Id<T>^ other)
        {
            throw gcnew System::NotImplementedException();
        }
    };
