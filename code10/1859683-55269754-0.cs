    public void SetTControls()
    {
         Value1_tbx.Visible = true;
         Value1_tbx.Text = some_text_value;
         Value_ddl.Visible = false; 
         Value_Date_tbx.Visible = false;
         Value_Date_calendar_img.Visible = false;
         Value_rbl.Visible = false;
    }
    
    public void SetSControls()
    {
        Value1_tbx.Visible = false;
        Value_ddl.Visible = true;
        Value_ddl.Text = some_select_box_value;
        Value_Date_tbx.Visible = false;
        Value_Date_calendar_img.Visible = false;
        Value_rbl.Visible = false;
    }
    
    public void SetDControls()
    {
        Value1_tbx.Visible = false;
        Value_ddl.Visible = false;
        Value_Date_tbx.Visible = true;
        Value_Date_calendar_img.Visible = true;
        Value_Date_tbx.Text = some_date_value;
        Value_rbl.Visible = false;
    }
    public void SetRControls()
    {
        Value1_tbx.Visible = false;
        Value_ddl.Visible = false;
        Value_Date_tbx.Visible = false;
        Value_Date_calendar_img.Visible = false;
        Value_rbl.Visible = true;
        Value.rbl.Text = some_value;
    }
