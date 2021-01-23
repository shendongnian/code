    void AnalyzeForHandShaking(Socket socketin, string Message)
        {
            Socket handler = socketin;
            try
            {
                Message = Message.Trim();
                if (!string.IsNullOrEmpty(Message.Trim()))
                   // if (Message.Equals("~"))
                    {
                       // string Serial = getSerialFromSocket(socketin).Trim();
                        DateTime dt = DateTime.Now; 
                        if (handler!=null)
                        //if there is serial in hastable
                        if (!arrIPTimeHandShaking.ContainsKey(handler))
                        {
                            arrIPTimeHandShaking.Add(handler, dt);
                        }
                        else
                        {
                            arrIPTimeHandShaking[handler] = dt;
                        }
                    }
            }
            catch
            {
            }
        }
