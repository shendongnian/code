      using (var filestream = new VarbinaryStream(
                                dbCtx.Database.Connection.ConnectionString,
                                "Binaries",
                                "Content",
                                "Id",
                                binary.Id,
                                true))
      {
        postedFile.InputStream.CopyTo(filestream);
      }
