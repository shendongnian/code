    for (Int32 idx = 0; idx < formCollection.Count; idx += 1)
                        {
                        String Name = formCollection.Keys[idx];
                        String value = formCollection[idx];
    
                        if (Name.Substring(0, 3).ToLower() == "chk")
    
                            {
                            Response.Write(Name + " is a checkbox <br/>");
                            }
                        else if (Name.Substring(0, 5).ToLower() == "txtar")
                            {
                            Response.Write(Name + " is a text area <br/>");
                            }
                        else if (Name.Substring(0, 2).ToLower() == "rd")
                            {
                            Response.Write(Name + " is a RadioButton <br/>");
                            }
    
                        }
