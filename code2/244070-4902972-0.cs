    Foo ReadFoo(Byte[] bytes)
    {
         Foo foo = new Foo();
         BinaryReader reader = new BinaryReader(new MemoryStream(bytes));
         foo.ID = reader.ReadUInt32();
         int userNameCharCount = reader.ReadUInt32();
         foo.UserName = new String(reader.ReadChars(userNameCharCount));
         int fullNameCharCount = reader.ReadUInt32();
         foo.FullName = new String(reader.ReadChars(fullNameCharCount));
         return foo;
    }
