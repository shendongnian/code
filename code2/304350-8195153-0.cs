    using System;
    using System.Collections.Generic;
    using System.Data.OleDb;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace OleDbParameterFix {
        static class Program {
            [STAThread]
            static void Main() {
                string connectionString = @"provider=vfpoledb;data source=data\northwind.dbc";
                using (var connection = new OleDbConnection(connectionString))
                using (var command = connection.CreateCommand()) {
                    command.CommandText = "select count(*) from orders where orderdate=@date or requireddate=@date or shippeddate=@date";
                    command.Parameters.Add("date", new DateTime(1996, 7, 11));
    
                    connection.Open();
    
                    OleDbParameterRewritter.Rewrite(command);
                    var count = command.ExecuteScalar();
    
                    connection.Close();
                }
            }
        }
    
        public class OleDbParameterRewritter {
            public static void Rewrite(OleDbCommand command) {
                HandleMultipleParameterReferences(command);
                ReplaceParameterNamesWithQuestionMark(command);
            }
    
            private static void HandleMultipleParameterReferences(OleDbCommand command) {
                var parameterMatches = command.Parameters
                                              .Cast<OleDbParameter>()
                                              .Select(x => Regex.Matches(command.CommandText, "@" + x.ParameterName))
                                              .ToList();
    
                // Check to see if any of the parameters are listed multiple times in the command text. 
                if (parameterMatches.Any(x => x.Count > 1)) {
                    var newParameters = new List<OleDbParameter>();
    
                    // order by descending to make the parameter name replacing easy 
                    var matches = parameterMatches.SelectMany(x => x.Cast<Match>())
                                                  .OrderByDescending(x => x.Index);
    
                    foreach (Match match in matches) {
                        // Substring removed the @ prefix. 
                        var parameterName = match.Value.Substring(1);
    
                        // Add index to the name to make the parameter name unique. 
                        var newParameterName = parameterName + "_" + match.Index;
                        var newParameter = (OleDbParameter)((ICloneable)command.Parameters[parameterName]).Clone();
                        newParameter.ParameterName = newParameterName;
    
                        newParameters.Add(newParameter);
    
                        // Replace the old parameter name with the new parameter name.   
                        command.CommandText = command.CommandText.Substring(0, match.Index)
                                                + "@" + newParameterName
                                                + command.CommandText.Substring(match.Index + match.Length);
                    }
    
                    // The parameters were added to the list in the reverse order to make parameter name replacing easy. 
                    newParameters.Reverse();
                    command.Parameters.Clear();
                    newParameters.ForEach(x => command.Parameters.Add(x));
                }
            }
    
            private static void ReplaceParameterNamesWithQuestionMark(OleDbCommand command) {
                for (int index = command.Parameters.Count - 1; index >= 0; index--) {
                    var p = command.Parameters[index];
                    command.CommandText = command.CommandText.Replace("@" + p.ParameterName, "?");
                }
            }
        }
    }
