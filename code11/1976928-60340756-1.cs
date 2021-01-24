    public string GuardarCotizacion(string json)
            {
    
                string SP_INSERTA_COTIZACIONPI = "SVI_CPI_COTIZACION_PI";
                var cotizaciones = JsonConvert.DeserializeObject<List<Cotizacion>>(json);
    
                foreach (var cotizacion in cotizaciones)
                {
                    using (SqlConnection conexion = new SqlConnection(Inventa.PazCorp.Data.BaseDatos.StringConexionGestionContactos(System.Configuration.ConfigurationManager.AppSettings["ambiente"].ToString())))
                    {
                        conexion.Open();
                        using (SqlCommand comm = new SqlCommand(SP_INSERTA_COTIZACIONPI, conexion))
                        {
                            comm.CommandType = System.Data.CommandType.StoredProcedure;
                            comm.Parameters.AddWithValue("IDCOTIZACION", cotizacion.idCotizacion);
                            comm.Parameters.AddWithValue("IDPROYECTO", cotizacion.idProyecto);
                            comm.Parameters.AddWithValue("NOMBRE_PROYECTO", cotizacion.nombreProyecto);
                            comm.Parameters.AddWithValue("IDPRODUCTO", cotizacion.idProducto);
                            comm.ExecuteNonQuery(); //Here is where the error appears
                        }
                    }
                }
                return json;
            }
