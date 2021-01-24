csharp
[Test]
public void DefineTableDoesNotThrow() {
    // arrange
    var database = // create your instance here
    var db = database.Create();
    var table = null;
    // act & assert
    Assert.DoesNotThrow(() => table = db.DefineTable("IndexedTable"));
    // clean up
    database.DropTable("IndexedTable");
}
csharp
[Test]
public void DefineTable() {
    // arrange
    var database = // create your instance here
    var db = database.Create();
    // act
    var table = db.DefineTable("IndexedTable");
    // assert
    // check if your table was created and exists.
    // do not care about the actual columns in here.
    // clean up
    database.DropTable("IndexedTable");
}
Next you want to test if your columns are created the way you want it.
This is another functionality so it should be another test.
It works just like `DefineTable` where you want to make sure it doesn't throw exceptions first and then you worry about if it worked correctly.
csharp
[Test]
public void ColumnAddDoesNotThrow() {
    // arrange
    var database = // create your instance here
    var db = database.Create();
    var table = db.DefineTable("IndexedTable");
    // act & assert
    Assert.DoesNotThrow(() => table.Add("Id", FieldType.Guid, false, true));
    // clean up
    database.DropTable("IndexedTable");
}
csharp
[Test]
public void ColumnAdd() {
    // arrange
    var database = // create your instance here
    var db = database.Create();
    var table = db.DefineTable("IndexedTable");
    // act
    table.Add("Id", FieldType.Guid, false, true);
    // assert
    // check if your table now has the correct column
    // cleanup
    database.DropTable("IndexedTable");
}
The next best thing to do is make that last test use multiple inputs.
This allows you to test edge cases with the same code by just adding another line of code.
Decorate the test with `[TestCaseAttribute(...)]` and add the required parameters to your test method.
This has to be done for every possible overload of `table.Column.Add(...)`.
Needless to say that this goes for `table.Indices.Add(...)` just as well.
