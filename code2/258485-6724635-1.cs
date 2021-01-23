      using (var filestream = new VarbinaryStream(
                                dbCtx.Database.Connection.ConnectionString,
                                "Binaries",
                                "Content",
                                "Id",
                                binary.Id))
      {
        postedFile.InputStream.CopyTo(filestream);
      }
