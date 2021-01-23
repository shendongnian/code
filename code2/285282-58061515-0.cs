+----+------------------+-----------+---------------------+
| Id |       Name       | Username  |        Email        |
+----+------------------+-----------+---------------------+
|  1 | Leanne Graham    | Bret      | Sincere@april.biz   |
|  2 | Ervin Howell     | Antonette | Shanna@melissa.tv   |
|  3 | Clementine Bauch | Samantha  | Nathan@yesenia.net  |
+----+------------------+-----------+---------------------+
`klassify` will generate a file called `Users.cs` that looks like this:
cs
    public class User 
    {
        public int Id {get; set; }
        public string Name { get;set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
It will output one file for every table.  Discard what you don't use.
__Usage__
 --out, -o:
        output directory     << defaults to the current directory >>
 --user, -u:
        sql server user id   << required >>
 --password, -p:
        sql server password  << required >>
 --server, -s:
        sql server           << defaults to localhost >>
 --database, -d:
        sql database         << required >>
 --timeout, -t:
        connection timeout   << defaults to 30 >>
 --help, -h:
        show help
