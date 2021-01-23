        public dynamic Post(dynamic value)
        {            
            try
            {
                if (value != null)
                {
                    var valorCampos = "";
                    foreach (Newtonsoft.Json.Linq.JProperty item in value)
                    {
                        if (item.Name == "valorCampo")//property name
                            valorCampos = item.Value.ToString();
                    }                                           
                    
                }
            }
            catch (Exception ex)
            {
            
            }
            
        }
