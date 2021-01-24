                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            jsonResult.Append("");
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                jsonResult.Append(reader.GetValue(0).ToString());
                            }
                        }
                        var response = this.Request.CreateResponse(HttpStatusCode.OK);
                        response.Content = new StringContent(jsonResult.ToString(), Encoding.UTF8, "application/json");
                        return response;
                    }
