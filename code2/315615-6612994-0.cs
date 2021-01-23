                    IOrderedDictionary keys = gv_courses.DataKeys[index].Values;
                    string[] keysTemp = new string[4];
                    keysTemp[0] = keys[0].ToString();
                    keysTemp[1] = keys[1].ToString();
                    keysTemp[2] = keys[2].ToString();
                    keysTemp[3] = keys[3].ToString();
                    Session["KeysCourse"] = keysTemp;
