protected override void OnModelCreating(ModelBuilder modelBuilder)
{
  if(Database.IsSqlServer())
  {
     modelBuilder.Query<ProviderRating>(entity =>
                {
                    entity.ToView("vGetProviderRatingData", "dbo");
                    entity.Property(e => e.col1)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                    entity.Property(e => e.col2)
                    .HasMaxLength(60)
                    .IsUnicode(false);
                    entity.Property(e => e.col3)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                    
                });
  }
  else
  {
    modelBuilder.Query<ProviderRating>().ToQuery(() =>
                 ProviderRatingFake.Select(m => new ProviderRating()
                 {
                     col1 = m.col1,
                     col2 = m.col2,
                     col3 = m.col3,
                 }
                ));
  }
}
The `ProviderRatingFake` class exactly similar to `ProviderRating` class
I also added this code in DbContext file (`ProviderQualityContext`)
 public virtual DbSet<ProviderRatingFake> ProviderRatingFake { get; set; }
 public virtual DbQuery<ProviderRating> ProviderRating { get; set; }
Then I tested like this
[TestMethod]
public void TestingWithInMemoryDb()
{
   var options = new DbContextOptionsBuilder<ProviderQualityContext>()
                .UseInMemoryDatabase(databaseName: "Read_From_Database")
                .Options;
  var fakeProviderRating = new ProviderRatingFake
            {
                col1 = 1,
                col2 = "Something",
                col3 = "Something",
            };
  using (var context = new ProviderQualityContext(options))
  {
    context.ProviderRatingFake.Add(fakeProviderRating);
    context.SaveChanges();
  }
  //use the newly created context and inject it into controller or repository
  using (var context = new ProviderQualityContext(options))
  {
    //use the test context here and make assertions that you are returning the
   //fake data
   //Note that the actual code uses the Query like this
   //This query will be populated with fake data using the else block
   //in the method OnModelCreating
   var returnedData = this.dbContext.Query<ProviderRating>().Where(m => m.col1 == 
   "Something")
  }
}
