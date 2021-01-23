    class MyPrintDocument : PrintDocument
    {
      public delegate void MyPrintPageEventHandler (object, PrintPageEventArgs, object); // added context!
      public event MyPrintPageEventHandler MyPrintPageEvent;
      public MyPrintDocument (object context) { m_context = context; }
      protected void OnPrintPage (PrintPageEventArgs args)
      {
        // raise my version of PrintPageEventHandler with added m_context
        MyPrintPageEvent (this, args, m_context);
      }
      object m_context;
    }
    public void PrintIt(string input)
    {
      MyPrintDocument pd = new MyPrintDocument(input);
      pd.MyPrintPage += new MyPrintPageEventHandler (PrintDocument_PrintSomething);
      pd.Print();
    }
    private void PrintDocument_PrintSomething(Object sender, PrintPageEventArgs e, object context)
    {
       e.Graphics.DrawString((string) context, new Font("Courier New", 12), Brushes.Black, 0, 0);
    }
