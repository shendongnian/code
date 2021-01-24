var DB = new dbEntities();
                    SqlParameter param1 = new SqlParameter("@FLAG", 1);
                    SqlParameter param2 = new SqlParameter("@Author", "");
                    SqlParameter Param3 = new SqlParameter("@Category", "");
                    SqlParameter param4 = new SqlParameter("@Title", Convert.ToString(id));
                    var medias = db.Database.SqlQuery<LibraryMediaEntry>("exec SP_TITILESEARCH @FLAG,@Author,@Category,@Title", param1, param2, Param3, param4).ToList();
