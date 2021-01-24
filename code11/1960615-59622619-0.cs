    public List<Root> definition()
            {
                var all = _db
                    .kpi_definition
                    .Include("KPI")
                    .Select(dl => new Root
                    {
                        //chart_type = dl.chart_type,
                        chart_type = new List<Chart>
                        {
                           new Chart { entity_name = dl.entity_name ,
                                       entity_display_name = dl.entity_display_name,
                                       kpi = new List<KPI>
                                       {
                                          new KPI {
                                                   kpi_name = dl.kpi_name,
                                                   kpi_display_name = dl.kpi_display_name,
                                                   required = new List<Required>
                                                   {
                                                       new Required
                                                       {
                                                           //kpi_required = dl.kpi_required
                                                       }
                                                   },
                                                   optional = new List<Optional>
                                                   {
                                                       new Optional
                                                       {
                                                           //kpi_optional = dl.kpi_optional
                                                       }
                                                   },
                                                   objects = new List<Objects>
                                                   {
                                                       new Objects
                                                       {
                                                           field_name = new List<FieldName>
                                                           {
                                                               new FieldName
                                                               {
                                                                entity_display_name = dl.entity_display_name,
                                                                type = "Select or Text",
                                                                @default = "default value(already selected)",
                                                                list = "",
                                                                ID = dl.ID
                                                               }
                                                           }
    
                                                       }
                                                   }
                                                  }
                                       }
                                     }
                        }
                    }).ToList();
                return all;
            }
