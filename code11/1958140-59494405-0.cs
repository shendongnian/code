        public static void Main() {
            var start = new DirectoryInfo( @"C:\Temp\Test" );
            CleanupFiles( start, 5, true );
        }
        /// <summary>
        /// <para>Remove any files last written to <paramref name="daysAgo"/> or before.</para>
        /// <para>Then recursively removes any empty sub-folders, but not the starting folder (when <paramref name="isRootFolder"/> is true).</para>
        /// <para>Attempts to remove any old read-only files also.</para>
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="daysAgo"></param>
        /// <param name="isRootFolder"></param>
        /// <param name="removeReadOnlyFiles"></param>
        public static void CleanupFiles( [NotNull] DirectoryInfo directory, int daysAgo, Boolean isRootFolder, Boolean removeReadOnlyFiles = true ) {
            if ( directory == null ) {
                throw new ArgumentNullException( paramName: nameof( directory ) );
            }
            if ( daysAgo < 1 ) {
                return;
            }
            directory.Refresh();
            if ( !directory.Exists ) {
                return;
            }
            var before = DateTime.UtcNow.AddDays( -daysAgo );
            // Check for aged files to remove
            Parallel.ForEach( directory.EnumerateFiles().AsParallel().Where( file => file.LastWriteTimeUtc <= before ), file => { 
                if ( file.IsReadOnly ) {
                    if ( removeReadOnlyFiles ) {
                        file.IsReadOnly = false;
                    }
                    else {
                        return;
                    }
                }
                file.Delete();
            } );
            foreach ( var subfolder in directory.EnumerateDirectories() ) {
                CleanupFiles( subfolder, daysAgo, false, removeReadOnlyFiles );
            }
            if ( !isRootFolder ) {
                if ( !directory.EnumerateDirectories().Any() && !directory.EnumerateFiles().Any() ) {
                    directory.Delete();
                }
            }
        }
    }
