    public ref class MyClass
    {
    ....
    public:
        void MyClass::Delegates(DataTable ^table)
        {
            table->RowChanged += gcnew DataRowChangeEventHandler (this, &MyNamespace::MyClass::RowChangedDelegate);
        }
     private:
        void MyClass::RowChangedDelegate(Object ^sender, DataRowEventArgs ^arg)
        {
              Handler ^handler = gcnew Handler();
              handler->DataChanged(sender, arg);
        }
     }
