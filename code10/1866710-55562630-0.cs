public class FileUpload
{
	public long Id { get; set; }
	public string FileName { get; set; }
	public string FilePath { get; set; }
}
2 - `InfoRecord` - As your question, a InfoRecord can have many files:
public class InfoRecord
{
	public long Id { get; set; }
	public string Title { get; set; }
	public ICollection<FileUploadRecord> Files { get; set; }
}
And lastly, the entity that "glues" them together:
3 - `FileUploadRecord` - It has an `FK` to `FileUpload` and to `InfoRecord`
public class FileUploadRecord
{
	public long Id { get; set; }
	// FK to InfoRecord. Usefull for update scenarious
	// without having to load the whole entity.
	public long InfoRecordId { get; set; }
	public InfoRecord InfoRecord { get; set; }
	// FK To the actual file upload
	public long FileId { get; set; }
	public FileUpload FileUpload { get; set; }
}
Then you can configure it using the `FluentAPI` like this:
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
	// Configure the Entity that "glues" InfoRecord and FileUploads. 
	// One InfoRecord can have many files, so we need a table to store that relationship.
	modelBuilder.Entity<FileUploadRecord>()
		.HasOne(s => s.InfoRecord)
		.WithMany(g => g.Files)
		.HasForeignKey(s => s.InfoRecordId);
	modelBuilder.Entity<FileUploadRecord>()
		.HasOne(p => p.FileUpload)
		.WithMany()
		.HasForeignKey(p => p.FileId);
}
And to query using `.Include` like you wanted is easy now. The query below loads all `InfoRecords` with each respective files. 
var recordsWithFiles = context.InfoRecords
                    .Include(p => p.Files)
                    .ThenInclude(p => p.FileUpload);
This is how the DB schema will look like:
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/4RquM.png
As per the "another_table", looks like it's a simple `one-to-one` relationship so, you can just use plain [EF Core Conventions](https://docs.microsoft.com/en-us/ef/core/modeling/relationships#conventions) for it. Of course `.Include` also works here.
public class AnotherTableRecord
{
	public long Id { get; set; }
	// FK To the actual file upload
	public long ImageId { get; set; }
	public FileUpload Image { get; set; }
}
