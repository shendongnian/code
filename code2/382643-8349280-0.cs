        public void SendMail()
        {
            dynamic Notes = null;
            object db = null;
            dynamic WorkSpace = null;
            dynamic UIdoc = null;
            string userName = null;
            string MailDbName = null;
            Notes = Activator.CreateInstance(Type.GetTypeFromProgID("Notes.NotesSession"));
            userName = Notes.userName;
            MailDbName = userName.Substring(0, 1) + userName.Substring(userName.Length - ((userName.Length - (userName.IndexOf(" ", 0) + 1)))) + ".nsf";
            db = Notes.GetDataBase(null, MailDbName);
            WorkSpace = Activator.CreateInstance(Type.GetTypeFromProgID("Notes.NotesUIWorkspace"));
            WorkSpace.ComposeDocument(null, null, "Memo");
            UIdoc = WorkSpace.currentdocument;
            Recipient = "test@email.com";
            CCD = "test2@email.com";
            UIdoc.FieldSetText("EnterSendTo", Recipient);
            UIdoc.FieldSetText("EnterCopyTo", CCD);
            Subject1 = "Subject";
            UIdoc.FieldSetText("Subject", Subject1);
            UIdoc.GotoField("Body");
            UIdoc.INSERTTEXT("This text goes to body");
            UIdoc = null;
            WorkSpace = null;
            db = null;
            Notes = null;
        }
