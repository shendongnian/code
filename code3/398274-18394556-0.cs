    while (reader.Read())
                {
                    Dispute disp = new Dispute();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (!reader.IsDBNull(i))
                        {
                            //Getting a property name associated to filed name
                            string mappedProperty = dataMapping[reader.GetName(i)];
                            //Getting handle to the property
                            PropertyInfo fld = typeof(Dispute).GetProperty(mappedProperty);
                            //Setting property value to field value
                            fld.SetValue(disp, reader.GetValue(i));
                        }
                    }
                }
