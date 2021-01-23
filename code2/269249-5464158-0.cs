    void GRService_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
            {
                List<Area> dataList = new List<Area>();
                MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(e.Result));
                DataContractJsonSerializer ser = new    DataContractJsonSerializer(dataList.GetType());
                dataList = ser.ReadObject(memoryStream) as List<Area>;
                memoryStream.Close();
                RoomAreas.ItemSource = dataList;
    
            }
