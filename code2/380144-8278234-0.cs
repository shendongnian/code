    DataTable dtnew = new DataTable();
    DataTable dt = (DataTable)XMLSerializerBL.Deserialize(xDocTable.OuterXml, XMLSerializerBL.OutputType.DataTable);
    DataView dvData = new DataView(dtData);
    dvData.RowFilter = "VKGRP='001'";
    
    grdmy.DataSource = dvData;
    grdmy.DataBind();
