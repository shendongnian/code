    foreach (var dr in 
            SqlRetrieve(cn, sp,
                        delegate (SqlCommand cmd) {
                            cmd.Parameters.Add("@paramname", System.Data.SqlDbType.Int).Value = someint;
                        }
            )
    ) {
    }
