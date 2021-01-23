    using System.Windows.Forms;
    using SinglecastEvent; // see SingleCastEvent Project for info or http://www.codeproject.com/Articles/12285/Implementing-an-event-which-supports-only-a-single
    
        namespace GenericTest
        {
        
            public class SimpleClass
            {
        
                private EventRaiser eventRaiser = new EventRaiser();
        
                public SimpleClass( EventRaiser ev )
                {
                    eventRaiser = ev;
                    simpleMethod();
        
                }
                private void simpleMethod()
                {
        
                    MessageBox.Show("in FileWatcher.simple() about to raise the event");
                    eventRaiser.RaiseEvent();
                }
            }
        }
