    // using Microsoft.Office.Interop.Access.Dao;
    // using static Microsoft.Office.Interop.Access.Dao.DatabaseTypeEnum;
    const string dbLangGeneral = ";LANGID=0x0409;CP=1252;COUNTRY=0";
    var engine = new DBEngine();
    var dbs = engine.CreateDatabase(@"c:\path\to\database.accdb", dbLangGeneral, dbVersion120);
    dbs.Close();
    dbs = null;
