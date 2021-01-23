    using namespace System;
    using namespace System::IO;
    using namespace System::Collections::Generic;
    using namespace System::Runtime::InteropServices;
    using namespace System::Runtime::Serialization::Formatters::Binary;
    
    System::Byte* _data;
    int _length;
    
    void Serialize(Object^ obj)
    {
      MemoryStream^ memstream = gcnew MemoryStream();
      BinaryFormatter^ formatter = gcnew BinaryFormatter();
      formatter->Serialize(memstream, obj);
      _length = (int)memstream->Length;
    
      UnmanagedMemoryStream^ stream = gcnew UnmanagedMemoryStream(_data, _length, _length, FileAccess::Write);
      memstream->WriteTo(stream);
      memstream->Close();
      stream->Close();
    }
    
    Object^ Deserialize()
    {
      UnmanagedMemoryStream^ stream = gcnew UnmanagedMemoryStream(_data, _length, _length, FileAccess::Read);
      BinaryFormatter^ formatter = gcnew BinaryFormatter();
      Object^ obj = formatter->Deserialize(stream);
      stream->Close();
      return obj;
    }
    
    [SerializableAttribute]
    ref class SerializableClass
    {
    public:
      IntPtr ptr;
      String^ string;
      List<SerializableClass^>^ list;
     };
    
    int main(array<String ^> ^args)
    {
      IntPtr ptr = Marshal::AllocHGlobal(1000);
      _data = (System::Byte*)ptr.ToPointer();
    
      array<SerializableClass^>^ arr = gcnew array<SerializableClass^>(2);
      for (int i = 0; i < arr->Length; i++)
      {
        SerializableClass^ c = gcnew SerializableClass();
        c->ptr = System::IntPtr(1234);
        c->list = gcnew List<SerializableClass^>();
    
        SerializableClass^ c2 = gcnew SerializableClass();
        c2->string = "Value";
        c->list->Add(c2);
        c->list->Add(c2);
    
        arr[i] = c;
      }
    
      Serialize(arr);
    
      array<SerializableClass^>^ deserializedClass = dynamic_cast<array<SerializableClass^>^>(Deserialize());
      
      return 0;
    }
