using System.Data.SQLite;
Create a database named mydb.db
SQLiteConnection.CreateFile("mydb.db"); 
Create a connection method
   
 public const string connectionString = @"Data Source=.\mydb.db;Version=3";
    public static SQLiteConnection ConnectionFactory()
    { return new SQLiteConnection(connectionString); }
 
Create a label Table method:
   
     public void CreateTable()
                {
                              string createTableQuery= 
                                 @"CREATE TABLE IF NOT EXISTS [LabelLanguage] (
                                 [id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                 [labelName] Text NULL,
                                 [englishValue] Text NULL,
                                 [germanValue] Text Null
                                )";
                    
                    using (IDbConnection connection = ConnectionFactory())
                    { connection.Execute(createTableQuery);}
                        
                }
Populate database table with info
    public void SaveQuery()
// a better approach would be to create a list of labels and values the use a for each to add them to database
//insert label 1 with values for house
        {      
        
string saveQuery = @""insert into LabelLanguage
                          (labelName, englishValue, germanValue) values 
                           (label1, house, hous)  "
        using (IDbConnection connection = new SQLiteConnection(connectionString))
               { 
                  connection.Execute(saveQuery);
               }
// insert label 2 for values of car
        saveQuery = @""insert into LabelLanguage
                                  (labelName, englishValue, germanValue) values 
                                   (label1, car, Wagen)  "
                 using (IDbConnection connection = new SQLiteConnection(connectionString))
                       { 
                          connection.Execute(saveQuery);
                       }
    
            }
    ```
Create a class to hold label values
    public class MyLabelValue
        {
    // should match database spellings
            public string labelName{ get; set; }
            public string englishValue{ get; set; }
            public string germanValue{ get; set; }
        }
add Dapper to the project [ maps classes ]
via nuget package manger
create a method to Get a list of labels and values from database
    public List<MyLabelValue> GetLabelLanguageValues(string languageName )
            {
                using (IDbConnection connection = ConnectionFactory())
                {
                    return connection.Query<MyLabelValue>($"SELECT labelName, "+ languageName +" FROM LabelLanguage").ToList();
                }
            }
Create a method to loop through each label on your form
'''
    void LoopThroughLabels(string languageName )
    {
     Label mylabel;
     list listOfLanguageValues = GetLabelLanguageValues(languageName );
    
         foreach (Control con in this.Controls) 
         {
             if (con.GetType() == typeof (Label)) //or any other logic
             {
                mylabel = (Label)con;
                foreach (MyLabelValue languageValue in listOfLanguageValues )
                 {
                  if (mylabel.name.ToString() == languageValue.labelName.ToString()
                      {
    ```
//uses reflection so make sure the property GetProperty("languageName ") is how the column in database is spelt and the property of the class MyLabelValue
               
        mylabel.Text= languageValue.GetType().GetProperty(languageName ).GetValue(languageValue, null); ;
                      }               
                 }
                 
                 
             }
         }
     }
Note: probably quite a few mistakes in there
and it relies on the exact naming of labels and also of language names
