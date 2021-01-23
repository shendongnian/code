      //1. Create class that represent row in text file for example
    
        public class cls_syslog_record
        {
            public DateTime? f1 {get;set;}
            public string f2 {get;set;}                
            public string f3 {get;set;}
            public string f4 {get;set;}        
        }
    
    //2. Create IEnumerable<cls_syslog_record> that used as source for DataGrid
    
        public IEnumerable<cls_syslog_record> get_line_seq_text()
        {
            cls_mvs_syslog_parser parser = new cls_mvs_syslog_parser();
            foreach (string record_line in File.ReadLines(this.filename))
            {
                cls_syslog_record text_record = parser.parse_syslog_text(record_line);
                if (text_record == null)
                {
                     continue;
                }
                yield return text_record;
             }
        }
    
    //3. set my IEnumerable object as source
    
        static private DataGrid make_text_viewer(string p_filename)
        {
            logger.Debug("start");
            DataGrid table_viewer;
            cls_file_line_seq fl_seq = new cls_file_line_seq(p_filename);
            table_viewer = new DataGrid();
            table_viewer.CanUserAddRows = false;
            table_viewer.CanUserDeleteRows = false;
            table_viewer.Columns.Add(create_column("Date Time", "timestamp"));
            table_viewer.Columns.Add(create_column("LPAR Name", "lpar_name"));
            table_viewer.Columns.Add(create_column("JOB ID", "job_id"));
            table_viewer.Columns.Add(create_column("Message", "message"));
            table_viewer.HeadersVisibility = DataGridHeadersVisibility.All;
            table_viewer.ItemsSource = fl_seq.get_line_seq_text();
            return table_viewer;
        }
    
    //4. Then setup binding
    
        static private DataGridColumn create_column(string header, string p_property_name)
        {
            DataGridTextColumn column = new DataGridTextColumn();
            column.Header = header;
            column.Binding = new Binding(p_property_name);            
            return column;
        }
    
    </code>
    </pre>
   
    
    
