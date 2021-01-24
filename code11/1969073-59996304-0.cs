c#
public class Attachment{
    public int Id { get; set; }
    public string Filename { get; set; }
    public string ContentType { get; set; }
    public virtual AttachmentBlob Blob { get; set; }
    //...
}
public class AttachmentBlob{
    public int Id { get; set; }
    public byte[] File { get; set; }
}
Map them to the same table, but not as an owned type;
c#
   modelBuilder.Entity<Attachment>(e => {
       e.HasOne(a => a.Blob)
        .WithOne()
        .HasForeignKey<AttachmentBlob>(b => b.Id);
   });
   modelBuilder.Entity<AttachmentBlob>(e => {
       e.ToTable("Attachment");
   });
Then you can read and write them either as byte arrays, or as streams;
c#
   public static async Task Read(DbContext db, Attachment attachment, Func<Stream,Task> callback)
   {
      await db.Database.OpenConnectionAsync();
      try {
         var conn = db.Database.GetDbConnection();
         var cmd = conn.CreateCommand();
         var parm = cmd.CreateParameter();
         cmd.Parameters.Add(parm);
         parm.ParameterName = "@id";
         parm.Value = attachment.Id;
         cmd.CommandText = "select File from Attachment where Id = @id";
         using (var reader = await cmd.ExecuteReaderAsync()){
            if (await reader.ReadAsync())
               await callback(reader.GetStream(0));
         }
      } finally {
         await db.Database.CloseConnectionAsync();
      }
   }
   public class AttachmentResult : FileStreamResult
   {
      private readonly DbContext db;
      private readonly Attachment attachment;
      public AttachmentResult(DbContext db, Attachment attachment) : base(new MemoryStream(), attachment.ContentType)
      {
         this.db = db;
         this.attachment = attachment;
      }
      public override async Task ExecuteResultAsync(ActionContext context)
      {
         await Read(db, attachment, async s => {
            FileStream = s;
            await base.ExecuteResultAsync(context);
         });
      }
   }
   public static async Task Write(DbContext db, Attachment attachment, Stream content)
   {
      await db.Database.OpenConnectionAsync();
      try {
         var conn = db.Database.GetDbConnection();
         var cmd = conn.CreateCommand();
         cmd.Transaction = db.Database.CurrentTransaction?.GetDbTransaction();
         var parm = cmd.CreateParameter();
         cmd.Parameters.Add(parm);
         parm.ParameterName = "@id";
         parm.Value = attachment.Id;
         parm = cmd.CreateParameter();
         cmd.Parameters.Add(parm);
         parm.ParameterName = "@content";
         parm.Value = content;
         cmd.CommandText = "update Attachment set File = @content where Id = @id";
         await cmd.ExecuteNonQueryAsync();
      } finally {
         await db.Database.CloseConnectionAsync();
      }
   }
   public static Task InsertAttachment(DbContext db, Attachment attachment, Stream content){
      var strat = db.Database.CreateExecutionStrategy();
      return strat.ExecuteAsync(async () => {
         using (var trans = await db.Database.BeginTransactionAsync())
         {
             db.Set<Attachment>.Add(attachment);
             await db.SaveChangesAsync();
             await Write(db, attachment, content);
             trans.Commit();
             db.ChangeTracker.AcceptAllChanges();
         }
      });
   }
