cs
// define typed projection to include all possible joined tables
// otherwise you will need to write complex logic to build expressions
class Projection
{
    public Document doc { get; set; }
    public DocumentField field1 { get; set; }
    public DocumentField field2 { get; set; }
    public DocumentField field3 { get; set; }
}
// initial query typed as IQueryable<Projection>
var query = db.GetTable<Document>().Select(d => new Projection() { doc = d });
// select required joins (replace it with your query rules logic)
var with1 = true;
var with2 = false;
var with3 = true;
// add requested joins, note how we copy records
// from previous query to new projection
if (with1)
    query = query.LeftJoin(
        db.GetTable<DocumentField>().TableName("field_1"),
        (d, f) => d.doc.Id == f.DocumentId,
        (d, f) => new Projection () { doc = d.doc, field1 = f });
if (with2)
    query = query.LeftJoin(
        db.GetTable<DocumentField>().TableName("field_2"),
        (d, f) => d.doc.Id == f.DocumentId,
        (d, f) => new Projection() { doc = d.doc, field1 = d.field1, field2 = f });
if (with3)
    query = query.LeftJoin(
        db.GetTable<DocumentField>().TableName("field_3"),
        (d, f) => d.doc.Id == f.DocumentId,
        (d, f) => new Projection() { doc = d.doc, field1 = d.field1, field2 = d.field2, field3 = f });
// add filters
if (with1)
    query = query.Where(r => r.field1.FilterMe == "test1");
if (with2)
    query = query.Where(r => r.field2.FilterMe == "test2");
if (with3)
    query = query.Where(r => r.field3.FilterMe == "test3");
// select only documents
query.Select(r => r.doc).ToArray();
result:
sql
SELECT
	[d].[Id]
FROM
	[Document] [d]
		LEFT JOIN [field_1] [f_1] ON [d].[Id] = [f_1].[DocumentId]
		LEFT JOIN [field_3] [f_2] ON [d].[Id] = [f_2].[DocumentId]
WHERE
	[f_1].[FilterMe] = N'test1' AND [f_2].[FilterMe] = N'test3'
