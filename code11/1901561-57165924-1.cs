SQL
CREATE TABLE [dbo].[Parent]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (50) NOT NULL,
[RowVersion] [timestamp] NOT NULL
) ON [PRIMARY]
ALTER TABLE [dbo].[Parent] ADD CONSTRAINT [PK_Parent] PRIMARY KEY CLUSTERED  ([ID]) ON [PRIMARY]
CREATE TABLE [dbo].[Child]
(
[ID] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (50) NOT NULL,
[RowVersion] [timestamp] NOT NULL,
[ParentID] [int] NOT NULL
) ON [PRIMARY]
ALTER TABLE [dbo].[Child] ADD CONSTRAINT [PK_Child] PRIMARY KEY CLUSTERED  ([ID]) ON [PRIMARY]
GO
CREATE VIEW [dbo].[ChildView]
WITH SCHEMABINDING
AS
SELECT Child.ID
, Child.Name
, Child.ParentID
, Child.RowVersion
, p.RowVersion AS ParentRowVersion
FROM dbo.Child
INNER JOIN dbo.Parent p ON p.ID = Child.ParentID
The view is updatable because it meets the [conditions for Sql Server views to be updatable](https://docs.microsoft.com/en-us/sql/t-sql/statements/create-view-transact-sql?view=sql-server-2017#updatable-views).
## Data
SQL
SET IDENTITY_INSERT [dbo].[Parent] ON
INSERT INTO [dbo].[Parent] ([ID], [Name]) VALUES (1, N'Parent1')
SET IDENTITY_INSERT [dbo].[Parent] OFF
SET IDENTITY_INSERT [dbo].[Child] ON
INSERT INTO [dbo].[Child] ([ID], [Name], [ParentID]) VALUES (1, N'Child1.1', 1)
INSERT INTO [dbo].[Child] ([ID], [Name], [ParentID]) VALUES (2, N'Child1.2', 1)
SET IDENTITY_INSERT [dbo].[Child] OFF
## Class model
C#
public class Parent
{
	public Parent()
	{
		Children = new HashSet<Child>();
	}
	public int ID { get; set; }
	public string Name { get; set; }
	public byte[] RowVersion { get; set; }
    public ICollection<Child> Children { get; set; }
}
public class Child
{
	public int ID { get; set; }
	public string Name { get; set; }
	public byte[] RowVersion { get; set; }
	public int ParentID { get; set; }
	public Parent Parent { get; set; }
	public byte[] ParentRowVersion { get; set; }
}
## Context
C#
public class TestContext : DbContext
{
	public TestContext(string connectionString) : base(connectionString){ }
	public DbSet<Parent> Parents { get; set; }
	public DbSet<Child> Children { get; set; }
	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Parent>().Property(e => e.RowVersion).IsRowVersion();
		modelBuilder.Entity<Child>().ToTable("ChildView");
		modelBuilder.Entity<Child>().Property(e => e.ParentRowVersion).IsRowVersion();
	}
}
## Bringing it together
This piece of code updates a `Child` while a fake concurrent user updates its `Parent`:
C#
using (var db = new TestContext(connString))
{
	var child = db.Children.Find(1);
	// Fake concurrent update of parent.
	db.Database.ExecuteSqlCommand("UPDATE dbo.Parent SET Name = Name + 'x' WHERE ID = 1");
	
	child.Name = child.Name + "y";
	db.SaveChanges();
}
Now `SaveChanges` throws the required `DbUpdateConcurrencyException`. When the update of the parent is commented out the child update succeeds.
I think the advantage of this method is that it's pretty independent of a data access library. All you need a an ORM that supports optimistic concurrency. A future move to EF-core won't be a problem.
