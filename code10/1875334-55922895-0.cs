        //get one instance, and use function in logic/business layer to create list
        //or rebuild function to return a list<EdgeData>
        public EdgeData GetEdgeData(int groupID)
        {
            connection.open();
            EdgeData edgeData;
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ad.Id, ad.Name, adType.Id, adType.Name, h.Data, chart.URL
                        from
                        tblAdapter ad JOIN
                        tblAdapterType adType ON ad.AdapterTypeId = adType.Id JOIN 
                        tblHealth h ON ad.HealthId = h.Id JOIN 
                        tblCharts chart ON ad.ChartId = chart.Id 
                        WHERE ad.GroupId = @GroupId");
        
            SqlDataReader data;
            String sql = sb.ToString();
            //Use sql injection instead of "+"
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@GroupId", groupID);
                data = cmd.ExecuteReader();
            }
            while (data.Read())
            {
                 int AdapterId = (int)data["ad.Id"]
                 string AdapterName = (string)data["ad.Name"]
                 int AdapterTypeId = ...
                 string AdapterTypeName = ...
                 bool IsConnected = ...
                 int MaxRefreshRate = ...
                 int AchievedRefreshRate = ..
                 string ChartLink = ..
                 edgeData = new EdgeData(AdapterId, AdapterName, etc...);
            }
            connection.Close();
            return edgeData;
        }
