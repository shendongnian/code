        public static DataTable Codes { get { return dtWLCodes; } }
        public static DataTable Songs { get { return dtWLSongs; } }
        public static DataTable SongLyrics { get { return dtWLSongLyrics; } }
        public static void Commit (string sTable = "")
        {
            if (sTable == "" || sTable == "Songs") { daWLSongs.Update(dslWLSongs.Songs); }
            if (sTable == "" || sTable == "SongLyrics") { daWLSongLyrics.Update(dslWLSongs.SongLyrics); }
