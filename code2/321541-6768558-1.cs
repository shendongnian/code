    public ref class MyClass
    {
    ....
    public:
        void MyClass::Delegates(DataTable ^table)
        {
            Handler ^handler = gcnew Handler();
            DataRowChangeEventForwarder& forwarder = 
                 gcnew DataRowChangeEventForwarder(
                 new EventHandler(handler, &MyNamespace::Handler::DataChanged)));
            table->RowChanged += gcnew DataRowChangeEventHandler (forwarder, &MyNamespace::MyClass::RowChangedDelegate);
        }
     }
     public ref class DataRowChangeEventForwarder 
     {
     private:
         EventHandler^ eventHandler;
     public:
         EventForwarder(EventHandler^ eventHandler) 
         {
              this->eventHandler = eventHander;
         }
         void MyClass::RowChangedDelegate(Object ^sender, DataRowEventArgs ^arg)
         {
              handler->DataChanged(sender, arg);
         }
     }
