    public class ObservableXmlTextWriter: XmlTextWriter
    {
       public delegate void XmlWriteHandler(object sender, XmlWriteEventArgs e);
    
       public event XmlWriteHandler XmlWritten;
    
       public event EventHandler XmlWriteComplete;
    
       public class XmlWriteEventArgs:EventArgs
       {
          public object Value{get; private set;}
          public XmlWriteEventArgs(object value) {Value = value;}
       }
    
       public override WriteValue(string value)
       {
          base.WriteValue(value);
          if(XmlWritten != null) XmlWritten(this, new XmlWriteEventArgs(value));
       }
       public override WriteValue(int value)
       {
          base.WriteValue(value);
          if(XmlWritten != null) XmlWritten(this, new XmlWriteEventArgs(value));
       }
    
       ... //override ALL Write methods to fire XmlWritten as above
    
       //Dispose will call Close(), so just make sure to do one or the other
       public override Close()
       {
          base.Close(value);
          if(XmlWriteComplete!= null) XmlWriteComplete(this, new EventArgs()));
       }
    }
    ...
    
    public void XmlWriteHandler(object sender, XmlWriteEventArgs e)
    {
       //Feel free to come up with your own algorithm for approaching 100%;
       //the number of times this event fires will be proportional to the
       //number of data elements (rows * columns) in the DataSet.
       MyProgressBar.Increment((MyProgressBar.Maximum - MyProgressBar.Value) * .05)
    }
    
    public void XmlWriteCompleteHandler(object sender, EventArgs e)
    {
       MyProgressBar.Value = MyProgressBar.Maximum;
    }
