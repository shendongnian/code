    public class TextBoxEx : TextBox
    {
        public string Format {get; set;}
        
        private object datasource
        public object Datasource
        { 
            get { return datasource;}
            set 
            {
                datasource = value;
                if(string.IsNullOrWhiteSpace(Format))
                   base.Text = datasource.ToString();
                else
                   base.Text = datasource.ToString(Format);
            }
        }
    } 
