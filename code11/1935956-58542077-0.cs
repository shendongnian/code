lang-cs
using System;
using Proj.Name.Infrastructure.DataAccess;
namespace Proj.Name.Models
{
    public class ListItem
    {
        [Column("name")]
        public string name { get; set; }
        [Column("other_column")]
        public string other { get; set; }
        [Column("third_column")]
        public string third { get; set; }
        ...
    }
}
to **uppercase**:
lang-cs
using System;
using Proj.Name.Infrastructure.DataAccess;
namespace Proj.Name.Models
{
    public class ListItem
    {
        [Column("NAME")]
        public string name { get; set; }
        [Column("OTHER_COLUMN")]
        public string other { get; set; }
        [Column("THIRD_COLUMN")]
        public string third { get; set; }
        ...
    }
}
Fixed my issue.
This is still confusing, as our other models/dapper calls are working and lowercase. **If anyone has insight on why this is inconsistent, please let me know.**
