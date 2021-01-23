 public void SaveUsingPureSql(string connectionString)
        {
            using (SqlCeConnection connection = new SqlCeConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    SaveSchemeToTable(connection, transaction);
                    SaveElementsAndPinsToTable(connection, transaction);
                    SaveNetWithConnectionsToTable(connection, transaction);
                    transaction.Commit();
                }
            }
        }
        private void SaveNetWithConnectionsToTable(SqlCeConnection conn, SqlCeTransaction transaction)
        {
            string insertNetsQuery = "INSERT INTO  Nets VALUES (@id,@IdName,@Name,@ElectricSchemes_IdElectricSchemes);";
            string insertNetConnectionQuery = "INSERT INTO  NetConnections VALUES (@id,@NetsIdNet,@ElementsIdElemtnt,@PinsIdPin,@ElectricSchemesIdElectricScheme);";
            
            SqlCeCommand netsCommand = new SqlCeCommand(insertNetsQuery, conn, transaction);
            SqlCeCommand netConnectionCommand = new SqlCeCommand(insertNetConnectionQuery, conn, transaction);
            netsCommand.Parameters.Add("@id", SqlDbType.BigInt);
            netsCommand.Parameters.Add("@ElectricSchemes_IdElectricSchemes", SqlDbType.BigInt);
            netsCommand.Parameters.Add("@IdName", SqlDbType.NVarChar);
            netsCommand.Parameters.Add("@Name", SqlDbType.NVarChar);
            
            netConnectionCommand.Parameters.Add("@id", SqlDbType.BigInt);
            netConnectionCommand.Parameters.Add("@NetsIdNet", SqlDbType.BigInt);
            netConnectionCommand.Parameters.Add("@ElementsIdElemtnt", SqlDbType.BigInt);
            netConnectionCommand.Parameters.Add("@PinsIdPin", SqlDbType.BigInt);
            netConnectionCommand.Parameters.Add("@ElectricSchemesIdElectricScheme", SqlDbType.BigInt);
            foreach (var net in scheme.Nets)
            {
                net.Id = lastNetId++;
                netsCommand.Parameters["@id"].Value = net.Id;
                netsCommand.Parameters["@ElectricSchemes_IdElectricSchemes"].Value = lastSchemeId;
                netsCommand.Parameters["@IdName"].Value = net.IdName;
                netsCommand.Parameters["@Name"].Value = net.Name;
                netsCommand.ExecuteNonQuery();
                foreach (var point in net.ConnectionPoints)
                {
                    netConnectionCommand.Parameters["@id"].Value = lastPinConnectionId++;
                    netConnectionCommand.Parameters["@NetsIdNet"].Value = net.Id;
                    netConnectionCommand.Parameters["@ElementsIdElemtnt"].Value = point.Item1.Id;
                    netConnectionCommand.Parameters["@PinsIdPin"].Value = point.Item2.Id;
                    netConnectionCommand.Parameters["@ElectricSchemesIdElectricScheme"].Value = lastSchemeId;
                    netConnectionCommand.ExecuteNonQuery();
                }
            }
        }
        private void SaveSchemeToTable(SqlCeConnection conn, SqlCeTransaction transaction)
        {
            string query = "INSERT INTO  ElectricSchemesSet VALUES (@id,@name,@SourceFileHash,@CreatedDate,@LastUpdatedDate);";
            SqlCeCommand command = new SqlCeCommand(query,conn,transaction);
            ValueType timeNow = DateTime.Now;
            scheme.Id = lastSchemeId;
            command.Parameters.AddWithValue("@id", scheme.Id);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@SourceFileHash", sourceFileHash);
            command.Parameters.AddWithValue("@CreatedDate", timeNow);
            command.Parameters.AddWithValue("@LastUpdatedDate", timeNow);
           
            command.ExecuteNonQuery();
        }
        private void SaveElementsAndPinsToTable(SqlCeConnection conn, SqlCeTransaction transaction)
        {
            string insertElementQuery =
                "INSERT INTO Elements VALUES (@id,@Func,@IdName,@Name,@Type,@ElectricSchemes_IdElectricSchemes);";
            string insertPinQuery =
                "INSERT INTO Pins VALUES (@id,@IdName,@Name,@Direction,@Type,@ElementIdElement, @ElectricSchemesIdElectricSchemes);";
            var elementCommand = new SqlCeCommand(insertElementQuery, conn, transaction);
            elementCommand.Parameters.Add("@id", SqlDbType.BigInt);
            elementCommand.Parameters.Add("@ElectricSchemes_IdElectricSchemes", SqlDbType.BigInt);
            elementCommand.Parameters.Add("@Func", SqlDbType.NVarChar);
            elementCommand.Parameters.Add("@IdName", SqlDbType.NVarChar);
            elementCommand.Parameters.Add("@Name", SqlDbType.NVarChar);
            elementCommand.Parameters.Add("@Type", SqlDbType.NVarChar);
            var pinCommand = new SqlCeCommand(insertPinQuery, conn, transaction);
            pinCommand.Parameters.Add("@id", SqlDbType.BigInt);
            pinCommand.Parameters.Add("@ElementIdElement", SqlDbType.BigInt);
            pinCommand.Parameters.Add("@ElectricSchemesIdElectricSchemes", SqlDbType.BigInt);
            pinCommand.Parameters.Add("@IdName", SqlDbType.NVarChar);
            pinCommand.Parameters.Add("@Name", SqlDbType.NVarChar);
            pinCommand.Parameters.Add("@Direction", SqlDbType.NVarChar);
            pinCommand.Parameters.Add("@Type", SqlDbType.NVarChar);
            foreach (var element in scheme.Elements)
            {
                element.Id = lastElementId++;
                elementCommand.Parameters["@id"].Value = element.Id;
                elementCommand.Parameters["@ElectricSchemes_IdElectricSchemes"].Value = lastSchemeId;
                elementCommand.Parameters["@Func"].Value = element.Func;
                elementCommand.Parameters["@IdName"].Value = element.IdName;
                elementCommand.Parameters["@Name"].Value = element.Name;
                elementCommand.Parameters["@Type"].Value = element.Type.ToString();
                elementCommand.ExecuteNonQuery();
                foreach (var pin in element.Pins)
                {
                    pin.Id = lastPinId++;
                    pinCommand.Parameters["@id"].Value = pin.Id;
                    pinCommand.Parameters["@ElementIdElement"].Value = element.Id;
                    pinCommand.Parameters["@ElectricSchemesIdElectricSchemes"].Value = lastSchemeId;
                    pinCommand.Parameters["@IdName"].Value = pin.IdName;
                    pinCommand.Parameters["@Name"].Value = pin.Name;
                    pinCommand.Parameters["@Direction"].Value = pin.PinDirection.ToString();
                    pinCommand.Parameters["@Type"].Value = pin.PinType.ToString();
                    pinCommand.ExecuteNonQuery();
                }
            }
        }
	
