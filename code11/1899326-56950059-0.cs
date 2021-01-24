var sql = @"<Your Sql Here>";
int count = session.CreateSQLQuery(sql)
    .ExecuteUpdate();
So something like below should work for you:
using (var session = SessionFactory.OpenSession())
{
    session.CreateSQLQuery("insert into DOCUMENTS (doc_id,document,doc_url) values SEQ_DOCUMENT_ID.nextval, empty_blob(), 'http://path_to_image');")
            .ExecuteUpdate();
}
