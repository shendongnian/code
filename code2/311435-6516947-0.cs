    [SqlFunction()]
    public static SqlString SendFromMittente(SqlString Messaggio, SqlString eMailDestinatario, SqlString From, SqlString SmtpHost, SqlString Utente, SqlString Password, SqlString Oggetto, SqlString Allegati, SqlBoolean SSL, SqlInt32 SmtpPort)
    {
        try
        {
            CDO.Message oMsg = new CDO.Message();
            CDO.IConfiguration iConfg;
            iConfg = oMsg.Configuration;
            ADODB.Fields oFields;
            oFields = iConfg.Fields;
            ADODB.Field oField;
            oField = oFields["http://schemas.microsoft.com/cdo/configuration/sendusing"];
            oField.Value = CDO.CdoSendUsing.cdoSendUsingPort;
            oField = oFields["http://schemas.microsoft.com/cdo/configuration/smtpserver"];
            oField.Value = SmtpHost.Value;
            oField = oFields["http://schemas.microsoft.com/cdo/configuration/smtpusessl"];
            oField.Value = SSL.Value.ToString();
            oField = oFields["http://schemas.microsoft.com/cdo/configuration/smtpserverport"];
            oField.Value = SmtpPort.Value.ToString();
            oField = oFields["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"];//Use 0 for anonymous 1 for authenticate
            oField.Value = CDO.CdoProtocolsAuthentication.cdoBasic;
            oField = oFields["http://schemas.microsoft.com/cdo/configuration/sendusername"];
            oField.Value = Utente.Value;
            oField = oFields["http://schemas.microsoft.com/cdo/configuration/sendpassword"];
            oField.Value = Password.Value;
            oFields.Update();
            oMsg.Subject = Oggetto.Value;
            oMsg.From = From.Value;
            oMsg.To = eMailDestinatario.Value;
            oMsg.TextBody = Messaggio.Value;
            if (!string.IsNullOrEmpty(Allegati.Value))
            {
                char[] sep = { ',' };
                string[] aryAllegati = Allegati.Value.Split(sep);
                foreach (string file in aryAllegati)
                {
                    oMsg.AddAttachment(file);
                    
                }
            }
            oMsg.Send();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Marshal.FinalReleaseComObject(oMsg);
            return new SqlString("true");
        }
        catch (Exception ex)
        {
            return new SqlString(ex.ToString());
        }
    }
