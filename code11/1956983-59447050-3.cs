    StringBuilder sb1=new StringBuilder();
    StringBuilder sb2=new StringBuilder();
    
    sb1.Append("Device #");
    sb2.Append("Pt.Name");
    foreach(var data in datas)
    {
        sb1.Append($" {data.deviceId}");
        sb2.Append($" {data.patName}");
    }
    sb1.Append(sb2.ToString());
