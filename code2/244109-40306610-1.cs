    using Microsoft.EntityFrameworkCore.Migrations;
    using System.Text;
    
    namespace EFGetStarted.AspNetCore.NewDb.Migrations
    {
        public partial class StoredProcedureTest : Migration
        {
            protected override void Up(MigrationBuilder migrationBuilder)
            {
    			StringBuilder sb = new StringBuilder();
    			sb.AppendLine("CREATE PROCEDURE GetBlogForAuthorName");
    			sb.AppendLine("@authorSearch varchar(100)");
    			sb.AppendLine("AS");
    			sb.AppendLine("BEGIN");
    			sb.AppendLine("-- SET NOCOUNT ON added to prevent extra result sets from interfering with SELECT statements.");
    			sb.AppendLine("SET NOCOUNT ON;");
    			sb.AppendLine("SELECT  Distinct Blogs.BlogId, Blogs.Url");
    			sb.AppendLine("FROM Blogs INNER JOIN");
    			sb.AppendLine("Posts ON Blogs.BlogId = Posts.BlogId INNER JOIN");
    			sb.AppendLine("PostsAuthors ON Posts.PostId = PostsAuthors.PostId Inner JOIN");
    			sb.AppendLine("Authors on PostsAuthors.AuthorId = Authors.AuthorId");
    			sb.AppendLine("Where Authors.[Name] like '%' + @authorSearch + '%'");
    			sb.AppendLine("END");
    
    			migrationBuilder.Sql(sb.ToString());
    		}
    
            protected override void Down(MigrationBuilder migrationBuilder)
            {
    			migrationBuilder.Sql("DROP PROCEDURE GetBlogForAuthorName");
    		}
        }
    }
 
