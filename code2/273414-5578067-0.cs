    namespace LuaInterfaceTest
    {
    class LuaTarModuleLoader
    {
        private LuaTarModuleLoader() { }
        ~LuaTarModuleLoader()
        {
            in_stream_.Close();
        }
        public LuaTarModuleLoader(Stream in_stream,Lua lua )
        {
            in_stream_ = in_stream;
            lua_ = lua;
        }
        public LuaFunction load(string modulename)
        {
            string lua_chunk = "";
            string filename = modulename + ".lua";
            in_stream_.Position = 0; // rewind
            Stream gzipStream = new BZip2InputStream(in_stream_);
            TarInputStream tar = new TarInputStream(gzipStream);
            TarEntry tarEntry;
            LuaFunction func = null;
            while ((tarEntry = tar.GetNextEntry()) != null)
            {
                if (tarEntry.IsDirectory)
                {
                    continue;
                }
                if (filename == tarEntry.Name)
                {
                    MemoryStream out_stream = new MemoryStream();
                    tar.CopyEntryContents(out_stream);
                    out_stream.Position = 0; // rewind
                    StreamReader stream_reader = new StreamReader(out_stream);
                    lua_chunk = stream_reader.ReadToEnd();
                    func = lua_.LoadString(lua_chunk, modulename);
                    string dum = func.ToString();
                    break;
                }
            }
            return func;
        }
        private Stream in_stream_;
        private Lua lua_;
    }
