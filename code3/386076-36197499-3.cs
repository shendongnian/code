    using (FileStream fs = new FileStream (path,FileMode.Create,FileAccess.ReadWrite,FileShare.None))
    {
      using (StreamWriter writer = new StreamWriter(fs))
      {
        NotesMimeEntity mimeEntity = notesDocument.GetMIMEEntity();
        if (mimeEntity != null)
            GetMIME(writer, mimeEntity);
      }
    }
