        internal static List<RoomType> FetchRoomTypeList()
        {
            List<RoomType> roomTypes = new List<RoomType>();
            SqlCommand commRoomTypeSelector = ConnectionManager.MainConnection.CreateCommand();
            commRoomTypeSelector.CommandType = CommandType.StoredProcedure;
            commRoomTypeSelector.CommandText = "Rooms.asp_RMS_RoomTypeList_Select";
            SqlDataAdapter da = new SqlDataAdapter(commRoomTypeSelector);
            DataSet ds = new DataSet();
            da.Fill(ds);
            roomTypes = (from rt in ds.Tables[0].AsEnumerable()
                         select new RoomType
                         {
                             RoomTypeID = rt.Field<int>("RoomTypeID"),
                             RoomTypeName = rt.Field<string>("RoomType"),
                             LastEditDate = rt.Field<DateTime>("LastEditDate"),
                             LastEditUser = rt.Field<string>("LastEditUser"),
                             IsActive = (rt.Field<string>("IsActive") == "Active")
                         }
                        ).ToList();
            return roomTypes;
        }
