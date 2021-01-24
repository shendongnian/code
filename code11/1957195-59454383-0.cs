                    Regex regex = new Regex("GO\r\n",RegexOptions.Singleline);
                    ArrayList updateCommands = new ArrayList(regex.Split(updateScript));
                    using (SqlConnection con = GetNewConnection()) {
                        con.Open();
                        foreach(string commandText in updateCommands) {
                            if (string.IsNullOrWhiteSpace(commandText)) continue;
                            using (SqlCommand cmd = new SqlCommand(commandText, con)) {
                                cmd.ExecuteNonQuery();
                            }
                        } // foreach
                    }
