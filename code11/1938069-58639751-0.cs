    public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
            {
                MyError myerror = new MyError()
                {
                    Details = error.Message,
                    Error = "Hello"
                };
                fault = Message.CreateMessage(version, "messsagefault", myerror);
    		}
