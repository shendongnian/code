    int rowNum = dataGridView1.Rows.Add();
    
    DataGridViewRow row = dataGridView1.Rows[rowNum];
    
    string[] data;
        if (String.Equals(e.Topic, "topicTemperature")){
            data = Encoding.UTF8.GetString(e.Message).Split(null);
            row.Cells["Sensor ID"].value = data[0];
            row.Cells["Temperature"].value = data[1];
        }
    
       if (String.Equals(e.Topic, "topicHumidity")){
           data = Encoding.UTF8.GetString(e.Message).Split(null);
           row.Cells["Humidity"].value = data[1];
       }
    
       if (String.Equals(e.Topic, "topicBatery")){
          data = Encoding.UTF8.GetString(e.Message).Split(null);
          row.Cells["Batery"].value = data[1];
          row.Cells["Date"].value = data[2];
       }
