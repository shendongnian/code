DataRelation rel = new DataRelation("ClientCategory", dtTree.Tables[0].Columns["TPAClientGroupId"], dtTree.Tables[1].Columns["TPAClientGroupId"], true);
rel.Nested = true;
dtTree.Relations.Add(rel);
foreach (DataColumn dc in dst.Tables[0].Columns)
{
	dc.ColumnMapping = MappingType.Attribute;
}
foreach (DataColumn dc in dst.Tables[1].Columns)
{
	dc.ColumnMapping = MappingType.Attribute;
}
XmlDataSource xmlD = new System.Web.UI.WebControls.XmlDataSource();
xmlD.ID = "clientGroupsxml";
xmlD.Data = dtTree.GetXml();
