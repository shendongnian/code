    public class Reader
    {
      public Reader()
      {
        // leave empty
      }
      public Read() {
        _axUsbHid = new AxUSBHIDInsert();
        ...
      }
    }
    public Form1()
    {
      InitializeComponent();
      _reader = new Reader();
      _reader.Read += Read;
      StartRead(_reader);
    }
    void StartRead(Reader reader) {
      Thread thread = new Thread(ReadRoutine);
      thread.SetApartmentState(ApartmentState.STA);
      thread.Start(reader);
    }
    
    void ReadRoutine(object param) {
      Reader reader = (Reader)param;
      reader.Read();
      while (AppIsAlive) { // add logic here
        // bad code, import GetMessage from user32.dll
        Application.DoEvents();
        Thread.Sleep(100);
      }
    }
