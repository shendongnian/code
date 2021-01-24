public Configuration()
{
    AutomaticMigrationsEnabled = false;
    SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());// the Golden Key
}
3. PM> add-migration initOrWhatEverYourName
4. PM> update-database
5. DONE.
