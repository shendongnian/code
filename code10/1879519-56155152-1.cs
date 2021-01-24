                            if (Application[sProcesoUnico].ToString() == "" || Application[sProcesoUnico] == null)
                            {
                                try
                                {
                                    // Process
                                }
                                catch (Exception)
                                {
                                    throw;
                                }
                                finally
                                {
                                    Application[sProcesoUnico] = ""; //release process 
                                }
                            }
