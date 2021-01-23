    switch (type)             
    {                 
        case 1:                     
            stopro = "new_project";     
            SqlParameter proj_naam = command.Parameters.Add("@proj_naam", SqlDbType.NVarChar);                     
            SqlParameter plaats = command.Parameters.Add("@plaats", SqlDbType.NVarChar);
            SqlParameter opdrachtgever = command.Parameters.Add("@opd_geef", SqlDbType.Int); 
            SqlParameter status = command.Parameters.Add("@status", SqlDbType.Int); 
            SqlParameter proj_id = command.Parameters.Add("@proj_id", SqlDbType.Int);
            proj_naam.Value = tb_proj_projectnaam.Text; 
            proj_naam.Direction = ParameterDirection.Input;   
            plaats.Value = tb_proj_plaats.Text; 
            plaats.Direction = ParameterDirection.Input; 
            opdrachtgever.Value = cb_proj_opdrachtgever.SelectedValue; 
            opdrachtgever.Direction = ParameterDirection.Input;
            status.Value = cb_proj_status.SelectedValue; 
            status.Direction = ParameterDirection.Input;
            proj_id.Value = id; 
            proj_id.Direction = ParameterDirection.Input;                    
            break;                 
        case 2:
            stopro = "new_bedrijf";                     
        // etc.
    }
