            StringBuilder sb = new StringBuilder();
            foreach (AddEntry list in addedEntry)
            {
                sb.AppendLine();
                sb.Append( list.URL.Equals("") ? "" : ("URL: " + list.URL + "\n") );
                sb.Append( list.SoftwareName.Equals("") ? "" : ("Software Name: " + list.SoftwareName + "\n" ));
                sb.Append( list.SerialCode.Equals("") ? "" : ("Serial Code: " + list.SerialCode + "\n") );
                sb.Append( list.UserName.Equals("") ? "" : ("User Name: " + list.UserName + "\n") );
                sb.Append( list.Password.Equals("") ? "" : ("Password: " + list.Password + "\n") );
                sb.AppendLine();
            }
            mainWindow.ChangeTextBox = sb.ToString();
