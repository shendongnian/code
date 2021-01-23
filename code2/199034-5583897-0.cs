                                parameter = new object[4];
                                parameter[0] = @sFileName;
                                parameter[1] = 1;
                                parameter[2] = Type.Missing;
                                parameter[3] = Type.Missing;
                                oMailItemAttachments.GetType().InvokeMember("Add", System.Reflection.BindingFlags.InvokeMethod, null, oMailItemAttachments, parameter);
