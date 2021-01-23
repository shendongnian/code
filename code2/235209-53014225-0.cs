    foreach (dynamic item in mailItems)
            {
                if (item is MailItem)
                {
                    Response.Write("Sender: ");
                    Response.Write(item.SenderEmailAddress);
                    Response.Write(" - To:");
                    Response.Write(item.To);
                    Response.Write("<br>");
                }
            }
