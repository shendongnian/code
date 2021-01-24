<?xml version="1.0" standalone="yes"?>
<DocumentElement>
  <DataTable1>
    <XRefCode>1578</XRefCode>
    <Name>1578</Name>
    <PieceRate>0</PieceRate>
    <Org xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
      <OrgXRefCode>terminalA</OrgXRefCode>
    </Org>
  </DataTable1>
</DocumentElement>
You can achieve desired behavior by defining custom type for last columns of your DataTable
public class Org
{
    public string OrgXRefCode { get; set; }
}
Than your DataTable initialization could look as following:
var dataTable = new DataTable("DataTable2");
dataTable.Columns.AddRange(new DataColumn[]{
    new DataColumn("XRefCode"),
    new DataColumn("Name"),
    new DataColumn("PieceRate"),
    new DataColumn("Org", typeof(Org))
});
var dataRow = dataTable.NewRow();
dataRow["XRefCode"] = 1578;
dataRow["Name"] = 1578;
dataRow["PieceRate"] = 0;
dataRow["Org"] = new Org()
{
    OrgXRefCode = "terminalA"
};
dataTable.Rows.Add(dataRow);
calling ```dataTable.WriteXml()``` will produce your expected XML
