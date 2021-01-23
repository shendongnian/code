     private void SendMessage(String p)
            {
                if (p != "")
                {
                    p = HttpUtility.UrlEncode(p, System.Text.Encoding.UTF8);
                    swSender.WriteLine(p);
                    swSender.Flush();
                    
                }
    
            }
