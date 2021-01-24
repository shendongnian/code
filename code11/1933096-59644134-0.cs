     var orderedQResultados = from resultado in dataSet.AsEnumerable()
                                                 orderby true
                                                 select dataRow;
                        //Ordenacion
                        foreach (Object object in listObjects)
                        {
                            if (oIQ.TextQuery.ToUpper().Contains(object.Columna.ToUpper()))
                            {
                                if (object.Value.ToUpper().Equals("DESC"))
                                    orderedQResultados = orderedQResultados.ThenByDescending(row => row[object.Columna]);
                                else
                                    orderedQResultados = orderedQResultados.ThenBy(row => row[object.Columna]);
                                dataSet.Clear();
                                dataSet.Merge(orderedQResultados.CopyToDataTable());
                            }
                        }
