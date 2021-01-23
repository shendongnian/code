        public static IEnumerable<Fileinfo> EnumerateMatches( string directory, string filenameonly, 
            bool dirs_only )
        {
            DirectoryInfo directory_info = new DirectoryInfo( directory );
            if( dirs_only )
            {
                DirectoryInfo[] infos = directory_info.GetDirectories( filenameonly );
                foreach( DirectoryInfo info in infos )
                {
                    string subpathonly = Path.Combine( directory, info.Name );
                    yield return new Fileinfo( info.FullName, true, info.LastWriteTime, 0 );
                }
            }
            else
            {
                FileInfo[] infos = directory_info.GetFiles( filenameonly );
                foreach( FileInfo info in infos )
                {
                    yield return new Fileinfo( info.FullName, false, info.LastWriteTime, info.Length );
                }
            }
        }
