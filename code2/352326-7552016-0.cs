    using System;
    using System.Web.UI;
    
    namespace TestApplication
    {
        public partial class Edit : UserControl
        {
            public string DefaultValue { get; set; }
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
            private static object EditClickKey = new object();
            public delegate void EditEventHandler(object sender, EditEventArgs e);
            public event EditEventHandler EditClick
            {
                add
                {
                    Events.AddHandler(EditClickKey, value);
                }
                remove
                {
                    Events.RemoveHandler(EditClickKey, value);
                }
            }
            protected void Button1_Click(object sender, EventArgs e)
            {
                OnEditClick(new EditEventArgs(DefaultValue));
            }
            protected virtual void OnEditClick(EditEventArgs e)
            {
                var handler = (EditEventHandler)Events[EditClickKey];
                if (handler != null)
                    handler(this, e);
            }
    
            public class EditEventArgs : EventArgs
            {
                private string data;
                private EditEventArgs()
                {
                }
                public EditEventArgs(string data)
                {
                    this.data = data;
                }
                public string Data
                {
                    get 
                    {
                        return data;
                    }
                }
            }
        }
    }
