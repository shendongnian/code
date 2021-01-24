c#
using System;
using System.Data;
using System.IO;
using System.Xml;
public class Program
{
	public static void Main()
	{
		string xml = @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>
<DATAPACKET Version=""2.0"">
	<METADATA>
		<FIELDS>
			<FIELD attrname=""CompanyID"" fieldtype=""string"" WIDTH=""10""/>
			<FIELD attrname=""Description"" fieldtype=""string"" WIDTH=""40""/>
		</FIELDS>
		<PARAMS/>
	</METADATA>
	<ROWDATA>
		<ROW CompanyID=""CC"" Description=""Contoso""/>
	</ROWDATA>
</DATAPACKET>
";
		XmlReader reader = XmlReader.Create(new StringReader(xml));
        DataSet dataSet = new DataSet();
		dataSet.ReadXml(reader, XmlReadMode.InferTypedSchema);
		var rowTable = dataSet.Tables["ROW"];
		var newRow = rowTable.NewRow();
		newRow["CompanyID"] = "APPL";
		newRow["Description"] = "Apple";
		newRow["ROWDATA_Id"] = 0; //This is what I was missing. This nests the row properly
		rowTable.Rows.Add(newRow);
		Console.WriteLine(dataSet.GetXml());
	}
}
Here is the output:
xml
<DATAPACKET Version="2.0">
  <METADATA>
    <PARAMS />
    <FIELDS>
      <FIELD attrname="CompanyID" fieldtype="string" WIDTH="10" />
      <FIELD attrname="Description" fieldtype="string" WIDTH="40" />
    </FIELDS>
  </METADATA>
  <ROWDATA>
    <ROW CompanyID="CC" Description="Contoso" />
    <ROW CompanyID="APPL" Description="Apple" />
  </ROWDATA>
</DATAPACKET>
[Here is the updated code running on dotnetfiddle](https://dotnetfiddle.net/Widget/QLkJ3K)
