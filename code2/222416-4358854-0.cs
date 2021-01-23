     public class ApplicationEventHandler
        {
            MessageFilterImp filter;
    
            public void Init()
            {
                filter = new MessageFilterImp();
                Application.AddMessageFilter(filter);
            }
        }
    
        internal class MessageFilterImp : IMessageFilter
        {
            public bool PreFilterMessage(ref Message m)
            {
                FormCollection forms = Application.OpenForms;
                foreach (Form form in forms)
                {
                    Console.WriteLine("---" + System.DateTime.Now);
                    Console.WriteLine(form.Name);
                }
                return false;
           
 }
    }
