            if (!this.IsOutputAttached)
            {
                string[] fields = this.ComponentMetaData.CustomPropertyCollection["Fields"].Value.ToString().Split(new Char[] { ',' });
                foreach (string _field in fields)
                {
                    IDTSOutputColumn100 _outputCol = ComponentMetaData.OutputCollection[0].OutputColumnCollection.New();
                    _outputCol.Name = _field;
                    _outputCol.SetDataTypeProperties(DataType.DT_STR, 20, 0, 0, 1252);
                }
                this.IsOutputAttached = true;
                base.OnOutputPathAttached(outputID);
            }
