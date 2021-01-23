        private bool StartsWithAny(string characters)
        {
             string aa = @"if exists(select * from tblSystems where  
                        systemName is not null and LEN(systemName)>0";
             for (int i = 0; i < characters.Length; i++)
             {
                 aa += " and SUBSTRING([login],1,1) = " + characters[i];
             }
             aa+=")";
             return db.ExecuteQuery<bool>(aa).Single();
        }
