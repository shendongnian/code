    public class Program {
        public static async Task Main( String[] args ) {
            await TestCleaningFolders.Test().ConfigureAwait(false);
        }
    }
    public class TestCleaningFolders {
        public static async Task Test() {
            var start = new DirectoryInfo( @"T:\Temp\Test" );
            var cancel = new CancellationTokenSource();
            var olderThan = DateTime.UtcNow.AddDays( -5 );
            var onException = new Action<Exception>( exception => Console.WriteLine( exception.ToString() ) ); //could easily be other logging or something..
            await CleanupFilesAsync( start, olderThan, deleteEmptyFolders: true, removeReadOnlyFiles: true, onException: onException, token: cancel.Token )
                .ConfigureAwait( false );
        }
        /// <summary>
        ///     <para>Remove any files last written to on or before <paramref name="olderThan" />.</para>
        ///     <para>Then recursively removes any empty sub-folders, but not the starting folder (when <paramref name="deleteEmptyFolders" /> is true).</para>
        ///     <para>Attempts to remove any old read-only files also.</para>
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="olderThan"></param>
        /// <param name="deleteEmptyFolders"></param>
        /// <param name="removeReadOnlyFiles"></param>
        /// <param name="onException"></param>
        /// <param name="token"></param>
        [NotNull]
        public static Task CleanupFilesAsync( [NotNull] DirectoryInfo folder, DateTime olderThan, Boolean deleteEmptyFolders, Boolean removeReadOnlyFiles,
            [CanBeNull] Action<Exception> onException, CancellationToken token ) {
            if ( folder is null ) {
                throw new ArgumentNullException( nameof( folder ) );
            }
            return Task.Run( async () => {
                folder.Refresh();
                if ( folder.Exists ) {
                    if ( ScanAndRemoveOldFiles() ) {
                        await ScanIntoSubFolders().ConfigureAwait( false );
                        RemoveFolderIfEmpty();
                    }
                }
            }, token );
            void Log<T>( T exception ) where T : Exception {
                Debug.WriteLine( exception.ToString() );
                if ( Debugger.IsAttached ) {
                    Debugger.Break();
                }
                onException?.Invoke( exception );
            }
            Boolean ScanAndRemoveOldFiles() {
                try {
                    foreach ( var file in folder.EnumerateFiles().TakeWhile( info => !token.IsCancellationRequested ) ) {
                        RemoveFileIfOld( file );
                        if ( token.IsCancellationRequested ) {
                            return false; //Added another check because a delete operation itself can take time (where a cancel could be requested before the next findfile).
                        }
                    }
                }
                catch ( UnauthorizedAccessException exception ) {
                    Log( exception );
                    return false;
                }
                catch ( SecurityException exception ) {
                    Log( exception );
                    return false;
                }
                catch ( DirectoryNotFoundException exception ) {
                    Log( exception );
                    return false;
                }
                catch ( IOException exception ) {
                    Log( exception );
                }
                return true;
            }
            void RemoveFileIfOld( FileInfo fileInfo ) {
                if ( fileInfo is null ) {
                    throw new ArgumentNullException( paramName: nameof( fileInfo ) );
                }
                try {
                    if ( !fileInfo.Exists || fileInfo.LastWriteTimeUtc > olderThan ) {
                        return;
                    }
                    if ( fileInfo.IsReadOnly ) {
                        if ( removeReadOnlyFiles ) {
                            fileInfo.IsReadOnly = false;
                        }
                        else {
                            return;
                        }
                    }
                    fileInfo.Delete();
                }
                catch ( FileNotFoundException exception ) {
                    Log( exception );
                }
                catch ( SecurityException exception ) {
                    Log( exception );
                }
                catch ( UnauthorizedAccessException exception ) {
                    Log( exception );
                }
                catch ( IOException exception ) {
                    Log( exception );
                }
            }
            async Task ScanIntoSubFolders() {
                try {
                    foreach ( var subfolder in folder.EnumerateDirectories().TakeWhile( info => !token.IsCancellationRequested ) ) {
                        await CleanupFilesAsync( subfolder, olderThan, deleteEmptyFolders: true, removeReadOnlyFiles: removeReadOnlyFiles, onException, token: token )
                            .ConfigureAwait( false );
                    }
                }
                catch ( DirectoryNotFoundException exception ) {
                    Log( exception );
                }
                catch ( SecurityException exception ) {
                    Log( exception );
                }
                catch ( UnauthorizedAccessException exception ) {
                    Log( exception );
                }
                catch ( IOException exception ) {
                    Log( exception );
                }
            }
            void RemoveFolderIfEmpty() {
                try {
                    if ( !deleteEmptyFolders || folder.EnumerateDirectories().Any() || folder.EnumerateFiles().Any() ) {
                        return;
                    }
                    folder.Delete();
                }
                catch ( FileNotFoundException exception ) {
                    Log( exception );
                }
                catch ( DirectoryNotFoundException exception ) {
                    Log( exception );
                }
                catch ( SecurityException exception ) {
                    Log( exception );
                }
                catch ( UnauthorizedAccessException exception ) {
                    Log( exception );
                }
                catch ( IOException exception ) {
                    Log( exception );
                }
            }
        }
    }
