    internal void set_Subject(string value)
    {
        if ((value != null) && MailBnfHelper.HasCROrLF(value))
        {
            throw new ArgumentException(SR.GetString("MailSubjectInvalidFormat"));
        }
        this.subject = value;
        if (((this.subject != null) && (this.subjectEncoding == null)) && 
             !MimeBasePart.IsAscii(this.subject, false))
        {
            this.subjectEncoding = Encoding.GetEncoding("utf-8");
        }
    }
