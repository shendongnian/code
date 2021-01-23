    SqlCommand cmd = new SqlCommand("Cup_INSFuneralHome", conn);
                   cmd.CommandType = CommandType.StoredProcedure;
    
                   SqlParameter[] param = new SqlParameter[9];
                   param[0] = new SqlParameter("@funeralhomename", SqlDbType.NVarChar);
                   param[0].Value = funeralhomename;
                   param[1] = new SqlParameter("@addressone", SqlDbType.NVarChar);
                   param[1].Value = street;
                   param[2] = new SqlParameter("@addresstwo", SqlDbType.NVarChar);
                   param[2].Value = street2;
                   param[3] = new SqlParameter("@cityname", SqlDbType.NVarChar);
                   param[3].Value = city;
                   param[4] = new SqlParameter("@State", SqlDbType.NVarChar);
                   param[4].Value = state;
                   param[5] = new SqlParameter("@zipCode", SqlDbType.NChar);
                   param[5].Value = zip;
                   param[6] = new SqlParameter("@Telephone", SqlDbType.NChar);
                   param[6].Value = tel;
                   param[7] = new SqlParameter("@PrimaryContact", SqlDbType.NVarChar);
                   param[7].Value = PrimaryContact;
                   param[8] = new SqlParameter("@EmailAddress", SqlDbType.NVarChar);
                   param[8].Value = EmailAddress;
    
    cmd.Parameters.AddRange(param );
