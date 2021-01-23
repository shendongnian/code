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
    
