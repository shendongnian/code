			try
			{
                //pFoto is a byte[] loaded in another method.
				if (pFoto != null && pFoto.Length > 0)
				{
					StringBuilder sentenciaSQL = new StringBuilder();
					sentenciaSQL.Append("INSERT INTO bd_imagenes:imagenes ");
					sentenciaSQL.Append("(identificador, cod_imagen, fecha_desde, fecha_hasta, fecha_grabacion, usuario, sec_transaccion, imagen) ");
					sentenciaSQL.Append("VALUES (?, 'FP', current, null, current, ?, 0, ?);");
					using (IfxConnection conIFX = new IfxConnection("Database=bd_imagenes; Server=xxxxxxxx; uid=xxxxxxx; password=xxxxxxxx; Enlist=true; Client_Locale=en_US.CP1252;Db_Locale=en_US.819"))
					{
						conIFX.Open(); //<- Abro la conexion.
						//Aqui convierto la foto en un BLOB:						
						IfxBlob blob = conIFX.GetIfxBlob();
						blob.Open(IfxSmartLOBOpenMode.ReadWrite);
						blob.Write(pFoto);
						blob.Close(); 
						//Creo el Comando con la SQL:
						using (IfxCommand cmd = new IfxCommand(sentenciaSQL.ToString(), conIFX))
						{
							//Agrego los parámetros en el mismo orden que la SQL:
							cmd.Parameters.Add(new IfxParameter()).Value = pCedula;
							cmd.Parameters.Add(new IfxParameter()).Value = SecurityHandler.Auditoria.NombreUsuario;
							cmd.Parameters.Add(new IfxParameter()).Value = blob;
							//Ejecuto la Consulta:
							Resultado = cmd.ExecuteNonQuery();
						}
						conIFX.Close();  
					}
					if (Resultado != 0) { retorno = true; }
				}
			}
			catch (IfxException ae)
			{
				if (exepcionesValidacion == null) { exepcionesValidacion = new ArrayList(); }
				exepcionesValidacion.Add(Util.CrearExcepcion(ae.Message, "ERROR_INESPERADO", ae.StackTrace));
			}
			catch (Exception ex)
			{
				if (exepcionesValidacion == null) { exepcionesValidacion = new ArrayList(); }
				exepcionesValidacion.Add(Util.CrearExcepcion(ex.Message, "ERROR_INESPERADO", ex.StackTrace));
			}
			return retorno;
		}
