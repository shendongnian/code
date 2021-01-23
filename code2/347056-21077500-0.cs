    ca.Property(x => x.Code, map =>
            {
                map.Column(cm => {
                    cm.Name("EnityCode"); 
                    cm.NotNullable(true);
                    cm.SqlType("varchar");
                }); 
            });
