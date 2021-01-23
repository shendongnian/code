                               {
                                   jm.Field1,
                                   jm.Field2,
                                   jm.Field3,
                                   jm.Field4,
                                   ........ 
                                   jm.n
                               }).ToList();
                GridView1.DataSource = jmDados;
                GridView1.DataBind();
            }
        }
