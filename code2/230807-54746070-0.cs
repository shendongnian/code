        public bool Key_AddExisting
        (
              string clave
            , int? idHito_FileServer
            , int? idTipoDocumental_Almacen
            , string tipoExp_CHJ
            , int idTipoExp_Verti2
            , int idMov_Verti2
        )
        {
            List<SqlParameter> pars = new List<SqlParameter>()
            {
                  new SqlParameter { ParameterName = "@Clave", Value = clave }
        LOOK -> , idHito_FileServer == null ? new SqlParameter { ParameterName = "@IdHito_FileServer", Value = DBNull.Value } : new SqlParameter { ParameterName = "@IdHito_FileServer", Value = idHito_FileServer }
        LOOK -> , idTipoDocumental_Almacen == null ?new SqlParameter { ParameterName = "@IdTipoDocumental_Almacen", Value = DBNull.Value } : new SqlParameter { ParameterName = "@IdTipoDocumental_Almacen", Value = idTipoDocumental_Almacen }
                , new SqlParameter { ParameterName = "@TipoExp_CHJ", Value = tipoExp_CHJ }
                , new SqlParameter { ParameterName = "@IdTipoExp_Verti2", Value = idTipoExp_Verti2 }
                , new SqlParameter { ParameterName = "@IdMov_Verti2", Value = idMov_Verti2 }
            };
            string sql = "INSERT INTO [dbo].[Enlaces_ClavesCHJ_MovimientosVerti2] " +
                "( " +
                "  [Clave] " +
                ", [IdHito_FileServer] " +
                ", [IdTipoDocumental_Almacen] " +
                ", [TipoExp_CHJ] " +
                ", [IdTipoExp_Verti2] " +
                ", [IdMov_Verti2] " +
                ") " +
                "VALUES" +
                "( " +
                "  @Clave" +
                ", @IdHito_FileServer" +
                ", @IdTipoDocumental_Almacen" +
                ", @TipoExp_CHJ" +
                ", @IdTipoExp_Verti2" +
                ", @IdMov_Verti2" +
                ")";
            return DbBasic.ExecNonQuery(ref this.conn, sql, pars);
        }
