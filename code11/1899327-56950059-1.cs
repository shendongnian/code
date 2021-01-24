var sql = @"<Your Sql Here>";
int count = session.CreateSQLQuery(sql)
    .ExecuteUpdate();
So something like below should work for you:
using (var session = SessionFactory.OpenSession())
{
    session.CreateSQLQuery("insert into DOCUMENTS (doc_id,document,doc_url) values SEQ_DOCUMENT_ID.nextval, empty_blob(), 'http://path_to_image');")
            .ExecuteUpdate();
}
By executing raw SQL, your transaction will still be honored. The only difference will be Session Level Cache. The stuff executed through raw SQL will not reflect Session Level Cache. If you are using `using` block, this should not be a big issue looking at limited scope of `Session`.
